public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string digits = phoneNumber.Replace("-", "");
        bool isNewYork = digits.StartsWith("212");
        bool isFake = digits.Substring(3, 3) == "555";
        string localNumber = digits.Substring(digits.Length - 4);
 
        return (isNewYork, isFake, localNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}