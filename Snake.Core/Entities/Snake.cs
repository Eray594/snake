using Snake.Core.Options;
using Snake.Core.PlayGround;

namespace Snake.Core.Entities;

internal class Snake
{
    internal readonly List<SnakePart> Body = new();
    internal Direction CurrentDirection;

    public Snake(int row, int column)
    {
        CurrentDirection = Direction.Right;
        Body.Add(new SnakePart(row, column));
        Body.Add(new SnakePart(row, column - 1));
    }

    private SnakePart Tail => Body.Last();
    public SnakePart Head => Body.First();

    internal void Grow(int by)
    {
        for (var i = 0; i < by; i++)
        {
            Body.Add(new SnakePart(Tail.Row, Tail.Column));
        }
    }

    internal bool HasCollisionWith(ICell cell)
    {
        return Body.Any(body => body.Row == cell.Row && body.Column == cell.Column);
    }

    internal bool IsEating(Food food)
    {
        return Head.Row == food.Row && Head.Column == food.Column;
    }

    internal bool IsEatingHimSelf()
    {
        var withoutHeader = Body.Skip(1);
        return withoutHeader.Any(b => b.Row == Head.Row && b.Column == Head.Column);
    }

    internal bool IsHead(SnakePart part)
    {
        return part.Row == Head.Row && part.Column == Head.Column;
    }

    internal void Move()
    {
        var part = CurrentDirection switch
        {
            Direction.Up => new SnakePart(Head.Row - 1, Head.Column),
            Direction.Down => new SnakePart(Head.Row + 1, Head.Column),
            Direction.Left => new SnakePart(Head.Row, Head.Column - 1),
            Direction.Right => new SnakePart(Head.Row, Head.Column + 1),
            _ => throw new ArgumentOutOfRangeException()
        };

        Body.Insert(0, part);
        Body.Remove(Tail);
    }

    internal void ChangeDirection(Direction direction)
    {
        ValidateDirection(direction);
    }

    private void ValidateDirection(Direction nextDirection)
    {
        CurrentDirection = nextDirection switch
        {
            Direction.Up => CurrentDirection is Direction.Down ? CurrentDirection : Direction.Up,
            Direction.Right => CurrentDirection is Direction.Left ? CurrentDirection : Direction.Right,
            Direction.Down => CurrentDirection is Direction.Up ? CurrentDirection : Direction.Down,
            Direction.Left => CurrentDirection is Direction.Right ? CurrentDirection : Direction.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(nextDirection), nextDirection, null)
        };
    }
}