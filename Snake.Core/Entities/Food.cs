using Snake.Core.PlayGround;

namespace Snake.Core.Entities;

public class Food : ICell
{
    public Food(int row, int column, int value)
    {
        Row = row;
        Column = column;
        Value = value;
    }
    public int Row { get; }
    public int Column { get; }
    public int Value { get; }
    
    internal bool HasCollisionWith(ICell cell)
    {
        return Row == cell.Row && Column == cell.Column;
    }
}
