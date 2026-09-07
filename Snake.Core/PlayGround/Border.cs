namespace Snake.Core.PlayGround;

public class Border : ICell
{
    public Border(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}