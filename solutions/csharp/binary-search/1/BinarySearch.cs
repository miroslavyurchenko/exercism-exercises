public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int left = 0;
        int right = input.Length - 1;
        
        while (left <= right)
        {
            int index = left + (right - left) / 2;

            if (input[index] == value)
            {
                return index;
            }

            if (input[index] > value)
            {
                right = index - 1;
            }
            else
            {
                left = index + 1;
            }
        }

        return -1;
    }
}