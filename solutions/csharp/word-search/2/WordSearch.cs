public class WordSearch
{
    private string[] grid;

    public WordSearch(string grid)
    {
        this.grid = grid.Split('\n');
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var result = new Dictionary<string, ((int, int), (int, int))?>();

        foreach (var word in wordsToSearchFor){
            result[word] = FindWord(word);
        }

        return result;
    }

    private ((int, int), (int, int))? FindWord(string word)
    {
        int[,] directions = {
            {-1, -1}, {0, -1}, {1, -1},
            {-1,  0},          {1,  0},
            {-1,  1}, {0,  1}, {1,  1} 
        };

        for (int y = 0; y < grid.Length; y++){
            for (int x = 0; x < grid[y].Length; x++){
                if (grid[y][x] != word[0])
                    continue;

                for (int d = 0; d < 8; d++){
                    int dx = directions[d, 0];
                    int dy = directions[d, 1];

                    if (WordFits(word, x, y, dx, dy)){
                        int endX = x + (word.Length - 1) * dx;
                        int endY = y + (word.Length - 1) * dy;

                        return ((x + 1, y + 1), (endX + 1, endY + 1));
                    }
                }
            }
        }

        return null;
    }

    private bool WordFits(string word, int startX, int startY, int dx, int dy)
    {
        for (int i = 0; i < word.Length; i++)
        {
            int x = startX + i * dx;
            int y = startY + i * dy;

            if (y < 0 || y >= grid.Length){
                return false;
            }
            if (x < 0 || x >= grid[y].Length){
                return false;
            }
            if (grid[y][x] != word[i]){
                return false;                
            }
        }

        return true;
    }
}