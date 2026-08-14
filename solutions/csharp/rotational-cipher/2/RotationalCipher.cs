public static class RotationalCipher
{
    
    
    public static string Rotate(string text, int shiftKey)
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string result = "";

        foreach (char c in text){
            if (char.IsLetter(c)){
                bool isUpper = char.IsUpper(c);
                char lower = char.ToLower(c);

                int index = alphabet.IndexOf(lower);
                int newIndex = (index + shiftKey) % 26;

                char newChar = alphabet[newIndex];

                if (isUpper){
                    newChar = char.ToUpper(newChar);
                }
                result += newChar;
            }else{
                result += c;
            }
        }

        return result;
    }
}