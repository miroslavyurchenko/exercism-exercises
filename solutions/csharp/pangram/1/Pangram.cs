using System.Text.RegularExpressions;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        input = input.ToLower();

        return Regex.Matches(input, "[a-z]")
                .Select(x => x.Value)
                .Distinct()
                .Count() == 26;
    }
}
