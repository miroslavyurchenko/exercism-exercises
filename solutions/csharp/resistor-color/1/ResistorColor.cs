public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        int i = 0;
        string[] colors = {"black","brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"};
        for(; i < colors.Length; i++){
            if(color == colors[i]){
                return i;
            }
        }
        
        return i;
    }

    public static string[] Colors()
    {
        string[] colors = {"black","brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"};
        
        return colors;
    }
}