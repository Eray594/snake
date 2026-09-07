using Snake.Core.PlayGround;

namespace Snake.Core.Entities;

public class Obstacle : ICell
{
    public int Row { get; }
    public int Column { get; }

    public Obstacle(int row, int column)
    {
        Row = row;
        Column = column;
    }

    internal bool HasCollisionWith(ICell cell)
    {
        return Row == cell.Row && Column == cell.Column;
    }
}