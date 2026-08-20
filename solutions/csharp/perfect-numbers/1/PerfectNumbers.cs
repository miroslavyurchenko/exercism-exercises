public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        int sum = 0;
        if(number <= 0){
            throw new ArgumentOutOfRangeException();
        }
        for(int i = 1; i < number; i++){
            if(number % i == 0){
                sum += i;
            }
        }
        if(sum == number){
            return Classification.Perfect;
        }else if(sum < number){
            return Classification.Deficient;
        }else{
            return Classification.Abundant;
        }
    }
}
