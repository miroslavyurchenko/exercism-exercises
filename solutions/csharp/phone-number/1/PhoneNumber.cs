using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string result = Regex.Replace(phoneNumber, @"\D", "");
        if(result.Length > 10 && result[0] == '1'){
            result = result.Remove(0, 1);
        }else if(result.Length != 10){
            throw new ArgumentException();
        }
        if(result[0] == '1' || result[0] == '0'){
            throw new ArgumentException();
        }else if(result[3] == '1' || result[3] == '0'){
            throw new ArgumentException();
        }
        
        return result;
    }
}