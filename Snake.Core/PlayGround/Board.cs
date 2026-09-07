using Snake.Core.Entities;
using Snake.Core.Options;

namespace Snake.Core.PlayGround;

internal class Board
{
    internal readonly ICell[,] Field;

    private readonly Obstacle[] obstacles;

    public Board(GameOptions options)
    {
        Field = new ICell[options.Size, options.Size];
        obstacles = SpawnObstacles(options);
    }

    private int Rows => Field.GetLength(0) - 1;
    private int Columns => Field.GetLength(1) - 1;

    internal void Assemble(Entities.Snake snake, List<Food> preys)
    {
        for (var row = 0; row <= Rows; row++)
        {
            for (var column = 0; column <= Columns; column++)
            {
                var cell = new Blank(row, column);
                if (CellIsOnBoarder(cell))
                {
                    Field[row, column] = new Border(row, column);
                    continue;
                }

                if (snake.HasCollisionWith(cell))
                {
                    var asSnakePart = new SnakePart(row, column);
                    if (snake.IsHead(asSnakePart))
                    {
                        Field[row, column] = new SnakeHead(row, column);
                    }
                    else
                    {
                        Field[row, column] = new SnakePart(row, column);
                    }
                    continue;
                }

                if (preys.Any(prey => prey.HasCollisionWith(cell)))
                {
                    Field[row, column] = new Food(row, column, 1);
                    continue;
                }

                if (obstacles.Any(obstacle => obstacle.HasCollisionWith(cell)))
                {
                    Field[row, column] = new Obstacle(row, column);
                    continue;
                }

                Field[row, column] = new Blank(row, column);
            }
        }
    }

    private static Obstacle[] SpawnObstacles(GameOptions options)
    {
        var random = new Random();
        var newObstacles = new Obstacle[options.ObstacleAmount - 1];
        for (var i = 0; i < options.ObstacleAmount - 1; i++)
        {
            int row;
            int column;
            do
            {
                row = random.Next(1, options.Size - 1);
                column = random.Next(1, options.Size - 1);
            } while (IsOnStartPosition(options, row, column));

            newObstacles[i] = new Obstacle(row, column);
        }

        return newObstacles;
    }

    private static bool IsOnStartPosition(GameOptions options, int row, int column)
    {
        return options.StartPosition.row == row &&
            options.StartPosition.column == column &&
            options.StartPosition.column + 1 < column;
    }

    internal bool CellIsOnBoarder(ICell cell)
    {
        return cell.Row <= 0 ||
               cell.Row >= Rows ||
               cell.Column <= 0 ||
               cell.Column >= Columns;
    }

    internal bool CellIsOnObstacle(ICell cell)
    {
        return obstacles.Any(obstacle => obstacle.HasCollisionWith(cell));
    }

    internal bool IsObstacleOnPosition(ICell cell)
    {
        return obstacles.Any(obstacle => obstacle.Row == cell.Row && obstacle.Column == cell.Column);
    }
}