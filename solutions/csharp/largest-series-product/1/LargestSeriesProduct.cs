public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span > digits.Length || span < 0){
            throw new ArgumentException();
        }

        long biggestNumber = 0;

        for (int i = 0; i <= digits.Length - span; i++){
            long number = 1;

            for (int j = 0; j < span; j++){
                if (!char.IsDigit(digits[i + j])){
                    throw new ArgumentException();
                }

                number *= digits[i + j] - '0';
            }

            if (number > biggestNumber){
                biggestNumber = number;
            }
        }

        return biggestNumber;
    }
}