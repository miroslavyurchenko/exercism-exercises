public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var counts = new Dictionary<int, int>();
        var stones = dominoes.ToList();

        if (stones.Count == 0){
            return true;
        }
        foreach (var (a, b) in stones){
            counts[a] = counts.GetValueOrDefault(a) + 1;
            counts[b] = counts.GetValueOrDefault(b) + 1;
        }

        if (counts.Values.Any(x => x % 2 != 0)){
            return false;
        }
        var visited = new HashSet<int> { stones[0].Item1 };
        var changed = true;

        while (changed){
            changed = false; 

            foreach (var (a, b) in stones){
                if (visited.Contains(a) && visited.Add(b)){ 
                    changed = true; 
                }

                if (visited.Contains(b) && visited.Add(a)){ 
                    changed = true;
                }
            }
        }

        return counts.Keys.All(x => visited.Contains(x));
    }
}