public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        string str = Convert.ToString(encodedCount, 2);
        int countOfEggs = 0;
        foreach(char i in str){
            if(i == '1'){
                countOfEggs++;
            }
        }
        return countOfEggs;
    }
}
