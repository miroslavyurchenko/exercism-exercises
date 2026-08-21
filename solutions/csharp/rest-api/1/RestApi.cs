using System.Text.Json;

public class User
{
    public string name { get; set; } = "";
    public Dictionary<string, double> owes { get; set; } = new();
    public Dictionary<string, double> owed_by { get; set; } = new();
    public double balance { get; set; }
}

public class RestApi
{
    private List<User> users;

    public RestApi(string database)
    {
        users = JsonSerializer.Deserialize<List<User>>(database)
                ?? new List<User>();
    }

    public string Get(string url, string? payload = null)
    {
        if (url != "/users")
            throw new ArgumentException();

        if (string.IsNullOrEmpty(payload))
            return JsonSerializer.Serialize(users);

        var request = JsonSerializer.Deserialize<UsersRequest>(payload)
                      ?? throw new ArgumentException();

        var selectedUsers = users
            .Where(u => request.users.Contains(u.name))
            .OrderBy(u => u.name)
            .ToList();

        SortUsers(selectedUsers);

        return JsonSerializer.Serialize(selectedUsers);
    }

    public string Post(string url, string payload)
    {
        if (url == "/add")
            return AddUser(payload);

        if (url == "/iou")
            return AddIou(payload);

        throw new ArgumentException();
    }

    private string AddUser(string payload)
    {
        var request = JsonSerializer.Deserialize<AddUserRequest>(payload)
                      ?? throw new ArgumentException();

        if (users.Any(u => u.name == request.user))
            throw new ArgumentException("User already exists");

        var newUser = new User
        {
            name = request.user,
            owes = new Dictionary<string, double>(),
            owed_by = new Dictionary<string, double>(),
            balance = 0
        };

        users.Add(newUser);

        return JsonSerializer.Serialize(newUser);
    }

    private string AddIou(string payload)
    {
        var request = JsonSerializer.Deserialize<IouRequest>(payload)
                      ?? throw new ArgumentException();

        var lender = users.FirstOrDefault(u => u.name == request.lender);
        var borrower = users.FirstOrDefault(u => u.name == request.borrower);

        if (lender == null || borrower == null)
            throw new ArgumentException("User not found");

        if (lender.name == borrower.name)
            throw new ArgumentException("Lender and borrower cannot be the same");

        if (request.amount < 0)
            throw new ArgumentException("Amount cannot be negative");

        /*
         * Case 1:
         * lender already owes borrower.
         *
         * Example:
         * Adam owes Bob 3
         * Adam lends Bob 2
         *
         * Result:
         * Adam owes Bob 1
         */
        if (lender.owes.TryGetValue(borrower.name, out double existingDebt))
        {
            double remaining = existingDebt - request.amount;

            if (remaining > 0)
            {
                lender.owes[borrower.name] = remaining;
                borrower.owed_by[lender.name] = remaining;
            }
            else if (remaining < 0)
            {
                /*
                 * The new IOU is larger than the existing debt.
                 *
                 * Example:
                 * Adam owes Bob 3
                 * Adam lends Bob 5
                 *
                 * Result:
                 * Bob owes Adam 2
                 */
                double newDebt = -remaining;

                lender.owes.Remove(borrower.name);
                borrower.owed_by.Remove(lender.name);

                lender.owed_by[borrower.name] = newDebt;
                borrower.owes[lender.name] = newDebt;
            }
            else
            {
                // Debt completely cancelled.
                lender.owes.Remove(borrower.name);
                borrower.owed_by.Remove(lender.name);
            }
        }
        else
        {
            /*
             * No debt in the opposite direction.
             *
             * Create/increase:
             * lender -> borrower
             */
            lender.owed_by[borrower.name] =
                lender.owed_by.GetValueOrDefault(borrower.name)
                + request.amount;

            borrower.owes[lender.name] =
                borrower.owes.GetValueOrDefault(lender.name)
                + request.amount;
        }

        UpdateBalance(lender);
        UpdateBalance(borrower);

        // Tests compare JSON strings, so keep dictionaries deterministic.
        SortUser(lender);
        SortUser(borrower);

        // API returns users alphabetically.
        var result = new[] { lender, borrower }
            .OrderBy(u => u.name)
            .ToList();

        return JsonSerializer.Serialize(result);
    }

    private void UpdateBalance(User user)
    {
        double totalOwedBy = user.owed_by.Values.Sum();
        double totalOwes = user.owes.Values.Sum();

        user.balance = totalOwedBy - totalOwes;
    }

    private void SortUser(User user)
    {
        user.owes = user.owes
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        user.owed_by = user.owed_by
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);
    }

    private void SortUsers(IEnumerable<User> users)
    {
        foreach (var user in users)
            SortUser(user);
    }
}

public class UsersRequest
{
    public List<string> users { get; set; } = new();
}

public class AddUserRequest
{
    public string user { get; set; } = "";
}

public class IouRequest
{
    public string lender { get; set; } = "";
    public string borrower { get; set; } = "";
    public double amount { get; set; }
}