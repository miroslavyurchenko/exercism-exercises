public static class SquareRoot
{
    public static int Root(int number)
    {
        double guess = number;

        while(guess * guess != number){
            guess = (guess + number / guess)/2;
        }
        return (int)guess;
    }
}
