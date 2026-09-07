using System.Timers;
using Snake.Core.Entities;
using Snake.Core.Options;
using Snake.Core.PlayGround;
using Timer = System.Timers.Timer;

namespace Snake.Core;

public class Game
{
    private readonly Board board;
    private readonly List<Food> preys;
    private readonly int size;
    private readonly Entities.Snake snake;
    private readonly Timer timer;
    private readonly IUserInterface userInterface;
    private readonly int size;
    public Game(GameOptions options, IUserInterface userInterface)
    {
        size = options.Size;
        snake = new Entities.Snake(options.StartPosition.row, options.StartPosition.column);
        preys = new List<Food>();
        board = new Board(options);
        this.userInterface = userInterface;
        timer = new Timer(options.Interval);
        timer.Elapsed += WhileRunning;
        SpawnPrey();
        
    }

    public bool IsRunning => timer.Enabled;
    
    private void WhileRunning(object? sender, ElapsedEventArgs e)
    {
        snake.Move();
        if (IsSnakeCollided())
        {
            GameOver();
            return;
        }

        foreach (var prey in preys.Where(prey => snake.IsEating(prey)))
        {
            snake.Grow(prey.Value);
            preys.Remove(prey);
            SpawnPrey();
            break;
        }

        board.Assemble(snake, preys);
        userInterface.Render(board.Field);
    }

    private void SpawnPrey()
    {
        var random = new Random();
        Food food;
        do
        {
            var row = random.Next(1, size - 1);
            var column = random.Next(1, size - 1);
            food = new Food(row, column, random.Next(1, 2));
        } while (snake.HasCollisionWith(food) || board.IsObstacleOnPosition(food));
        
        preys.Add(food);
    }

    private bool IsSnakeCollided()
    {
        return board.CellIsOnObstacle(snake.Head)
               || board.CellIsOnBoarder(snake.Head)
               || snake.IsEatingHimSelf();
    }

    public void ChangeDirection(Direction direction)
    {
        snake.ChangeDirection(direction);
    }

    public void Start()
    {
        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
    }

    private void GameOver()
    {
        timer.Stop();
        userInterface.GameOver();
    }
}