using Snake.Core;
using Snake.Core.Options;

namespace Snake.Console;

internal static class Program
{
    private static Game? game;

    public static void Main(string[] args)
    {
        game = new Game(new GameOptions(
                Size: 15,
                Interval: 200,
                ObstacleAmount: 5,
                StartPosition: (10, 10)),
            userInterface: new UserInterface());

        game.Start();
        while (true)
        {
            while (game.IsRunning)
            {
                MoveTo(System.Console.ReadKey().Key);
            }
        }
    }

    private static void MoveTo(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.W or ConsoleKey.UpArrow:
                game?.ChangeDirection(Direction.Up);
                break;
            case ConsoleKey.D or ConsoleKey.RightArrow:
                game?.ChangeDirection(Direction.Right);
                break;
            case ConsoleKey.S or ConsoleKey.DownArrow:
                game?.ChangeDirection(Direction.Down);
                break;
            case ConsoleKey.A or ConsoleKey.LeftArrow:
                game?.ChangeDirection(Direction.Left);
                break;
        }
    }
}