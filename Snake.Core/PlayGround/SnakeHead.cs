namespace Snake.Core.PlayGround;

public class SnakeHead : ICell
{
    public int Row { get; }
    public int Column { get; }

    public SnakeHead(int row, int column)
    {
        Row = row;
        Column = column;
    }
}