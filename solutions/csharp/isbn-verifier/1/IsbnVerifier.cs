public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        number = number.Replace("-", "");

        if (number == "" || number.Length != 10){
            return false;
        }

        int startCount = 10;
        int sum = 0;

        for (int i = 0; i < number.Length; i++){
            char c = number[i];

            if (c == 'X'){
                if (i != 9){
                    return false;
                }

                sum += 10 * startCount;
            }else if (char.IsDigit(c)){
                sum += (c - '0') * startCount;
            }else{
                return false;
            }

            startCount--;
        }

        return sum % 11 == 0;
    }
}