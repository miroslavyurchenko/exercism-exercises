class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length-1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length-1]++;
    }
  
    public bool HasDayWithoutBirds()
    {
        bool result = false;
        foreach(int i in birdsPerDay){
            if(i == 0){
                result = true;
            }
        }
        return result;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for(int i =0; i<numberOfDays; i++){
            count += birdsPerDay[i];
        } 
        return count;
    }

    public int BusyDays()
    {
        int days = 0;

        foreach(int i in birdsPerDay){
            if(i >= 5){
                days++;
            }
        }
    return days;
    }
}


