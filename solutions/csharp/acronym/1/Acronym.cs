public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string result = "";
        bool newWord = true;

        foreach (char c in phrase){
            if (c == '-' || char.IsWhiteSpace(c)){
                newWord = true;
            }
            else if (char.IsPunctuation(c)){
                
            }else if (newWord){
                result += char.ToUpper(c);
                newWord = false;
            }
        }

        return result;
    }
}