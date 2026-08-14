public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string stringNumber = number.ToString();
        int length = stringNumber.Length;
        int sum = 0;

        foreach(char c in stringNumber){
            int digit = int.Parse(c.ToString());
            sum += (int)Math.Pow(digit, length);
        }

        return sum == number;
    }
}