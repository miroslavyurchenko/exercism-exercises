public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        string result = "";
        int count = 0;
        
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string cipher = "";

        char[] cArray = alphabet.ToCharArray();
        for (int i = cArray.Length - 1; i > -1; i--){ 
            cipher += cArray[i];
        }

        foreach(char c in plainValue){
            
            if(char.IsLetter(c)){
                for(int i = 0; i < alphabet.Length; i++){
                    if(char.ToLower(c) == alphabet[i]){
                        result += cipher[i];
                        count++;
                        if(count%5 == 0){
                            result += ' ';
                        }
                    }
                }
            }
            
            if(char.IsNumber(c)){
                result += c;
                count++;
                if(count%5 == 0){
                    result += ' ';
                }
            }            
        }

        if(result.EndsWith(" ")){
            result = result.Substring(0, result.Length - 1);
        }
        
        return result;
    }
    
    public static string Decode(string encodedValue)
    {
        string result = "";
        int count = 0;

        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string cipher = "";

        char[] cArray = alphabet.ToCharArray();
        for (int i = cArray.Length - 1; i > -1; i--){ 
            cipher += cArray[i];
        }

        foreach(char c in encodedValue){
            
            if(char.IsLetter(c)){
                for(int i = 0; i < cipher.Length; i++){
                    if(char.ToLower(c) == cipher[i]){
                        result += alphabet[i];
                        count++;
                    }
                }
            }
            
            if(char.IsNumber(c)){
                result += c;
                count++;
            }            
        }

        if(result.EndsWith(" ")){
            result = result.Substring(0, result.Length - 1);
        }
        
        return result;
    }
}
