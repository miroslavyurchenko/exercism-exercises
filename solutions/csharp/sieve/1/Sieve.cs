public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2){
            return Array.Empty<int>();
        }

        bool[] isPrime = new bool[limit + 1];
        Array.Fill(isPrime, true);

        isPrime[0] = false;
        isPrime[1] = false;

        for (int p = 2; p * p <= limit; p++){
            if (isPrime[p]){
                for (int multiple = p * p; multiple <= limit; multiple += p){
                    isPrime[multiple] = false;
                }
            }
        }

        return Enumerable.Range(2, limit - 1).Where(n => isPrime[n]).ToArray();
    }
}