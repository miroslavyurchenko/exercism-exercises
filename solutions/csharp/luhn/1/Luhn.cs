public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = number.Replace(" ", "");

        if (number.Length <= 1){
            return false;
        }

        foreach (char c in number){
            if (!char.IsDigit(c)){
                return false;
            }
        }

        int sum = 0;

        for (int i = number.Length - 1; i >= 0; i--){
            int digit = number[i] - '0';

            if ((number.Length - 1 - i) % 2 == 1){
                digit *= 2;

                if (digit > 9){
                    digit -= 9;
                }
            }

            sum += digit;
        }

        return sum % 10 == 0;
    }
}