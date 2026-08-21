public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();

        foreach (var pair in old){
            int score = pair.Key;

            foreach (var letter in pair.Value){
                result.Add(letter.ToLower(), score);
            }
        }
        return result;
    }
}