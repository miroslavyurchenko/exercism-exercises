public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> count = new(){
            {'A', 0},
            {'C', 0},
            {'G', 0},
            {'T', 0}
        };
        
        foreach(char c in sequence){
            if(!count.ContainsKey(c)){
               throw new ArgumentException(); 
            }
            count[c]++;
        }

        return count;
    }
}