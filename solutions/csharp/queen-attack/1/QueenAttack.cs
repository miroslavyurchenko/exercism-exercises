public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        if (white.Row == black.Row){
            return true;
        }
        
        if (white.Column == black.Column){
            return true;
        }
        
        if (Math.Abs(white.Row - black.Row) == Math.Abs(white.Column - black.Column))
            return true;

        return false;
    }

    public static Queen Create(int row, int column)
    {
        if (row < 0 || row > 7){
            throw new ArgumentOutOfRangeException(nameof(row));
        }
        
        if (column < 0 || column > 7){
            throw new ArgumentOutOfRangeException(nameof(column));
        }
        
        return new Queen(row, column);
    }
}