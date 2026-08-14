public static class CollatzConjecture
{
    public static int Steps(int number)
    {

        if (number <= 0){
            throw new ArgumentOutOfRangeException(nameof(number));
        }
        
        int steps = 0;
        
        while(number != 1){
            
            if((number%2) != 0){
                number = (number*3)+1;
            }else{
                number = number /2;
            }
            steps++;
        }
        return steps;
    }
}