using System.Text;

public class RailFenceCipher
{
    private readonly int _rails;

    public RailFenceCipher(int rails)
    {
        _rails = rails;
    }

    public string Encode(string input)
    {
        if (_rails <= 1 || input.Length <= 1)
        {
            return input;
        }

        var rows = new StringBuilder[_rails];

        for (int i = 0; i < _rails; i++)
        {
            rows[i] = new StringBuilder();
        }
        
        int rail = 0;
        int direction = 1;

        foreach (char c in input)
        {
            rows[rail].Append(c);

            if (rail == 0)
            {
                direction = 1;
            }
            else if (rail == _rails - 1)
            {
                direction = -1;
            }

            rail += direction;
        }

        var result = new StringBuilder();

        foreach (var row in rows)
        {
            result.Append(row);
        }

        return result.ToString();
    }

    public string Decode(string input)
    {
        if (_rails <= 1 || input.Length <= 1)
        {
            return input;
        }

        int[] counts = new int[_rails];

        int rail = 0;
        int direction = 1;

        for (int i = 0; i < input.Length; i++)
        {
            counts[rail]++;

            if (rail == 0)
            {
                direction = 1;
            }
            else if (rail == _rails - 1)
            {
                direction = -1;
            }

            rail += direction;
        }

        string[] rows = new string[_rails];
        int position = 0;

        for (int i = 0; i < _rails; i++)
        {
            rows[i] = input.Substring(position, counts[i]);
            position += counts[i];
        }

        int[] indexes = new int[_rails];
        var result = new StringBuilder();

        rail = 0;
        direction = 1;

        for (int i = 0; i < input.Length; i++)
        {
            result.Append(rows[rail][indexes[rail]]);
            indexes[rail]++;

            if (rail == 0)
            {
                direction = 1;
            }
            else if (rail == _rails - 1)
            {
                direction = -1;
            }

            rail += direction;
        }

        return result.ToString();
    }
}
