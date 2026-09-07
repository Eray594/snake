namespace Snake.Core.PlayGround;

public class Blank : ICell
{
    public Blank(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}