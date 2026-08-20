public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var stones = dominoes.ToList();

        if (stones.Count == 0){
            return true;
        }
        
        var counts = new Dictionary<int, int>();

        foreach (var (a, b) in stones)
        {
            if (!counts.ContainsKey(a)){
                counts[a] = 0;
            }
            
            if (!counts.ContainsKey(b)){
                counts[b] = 0;
            }
            counts[a]++;
            counts[b]++;
        }

        foreach (var count in counts.Values){
            if (count % 2 != 0){
                return false;
            }
        }

        var connected = new List<int>();
        connected.Add(stones[0].Item1);

        bool changed = true;

        while (changed){
            changed = false;

            foreach (var (a, b) in stones){
                if (connected.Contains(a) && !connected.Contains(b)){
                    connected.Add(b);
                    changed = true;
                }

                if (connected.Contains(b) && !connected.Contains(a)){
                    connected.Add(a);
                    changed = true;
                }
            }
        }

        foreach (var number in counts.Keys){
            if (!connected.Contains(number)){
                return false;
            }
        }

        return true;
    }
}