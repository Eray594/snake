using Snake.Core;
using Snake.Core.Entities;
using Snake.Core.PlayGround;

namespace Snake.Console;

public class UserInterface : IUserInterface
{
    public void Render(ICell[,] field)
    {
        Reset();
        for (var row = 0; row <= field.GetLength(0); row++)
        {
            for (var column = 0; column <= field.GetLength(1); column++)
            {
                var cell = field[row, column];
                switch (cell)
                {
                    case Border or Obstacle:
                        ChangeConsoleColor(ConsoleColor.DarkGray);
                        System.Console.Write("  ");
                        break;
                    
                    case SnakeHead:
                        ChangeConsoleColor(ConsoleColor.Cyan);
                        System.Console.Write("  ");
                        break;
                    
                    case SnakePart:
                        ChangeConsoleColor(ConsoleColor.White);
                        System.Console.Write("  ");
                        break;

                    case Food:
                        ChangeConsoleColor(ConsoleColor.DarkMagenta);
                        System.Console.Write("  ");
                        break;
                    case Blank:
                        ChangeConsoleColor(ConsoleColor.Gray);
                        System.Console.Write("  ");
                        break;
                }
            }

            System.Console.WriteLine();
        }
    }

    public void GameOver()
    {
        Reset();
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(@"
   ____                         ___                 
  / ___| __ _ _ __ ___   ___   / _ \__   _____ _ __ 
 | |  _ / _` | '_ ` _ \ / _ \ | | | \ \ / / _ \ '__|
 | |_| | (_| | | | | | |  __/ | |_| |\ V /  __/ |   
  \____|\__,_|_| |_| |_|\___|  \___/  \_/ \___|_|");
    }

    private static void ChangeConsoleColor(ConsoleColor to)
    {
        System.Console.ForegroundColor = to;
        System.Console.BackgroundColor = to;
    }

    private static void Reset()
    {
        ChangeConsoleColor(ConsoleColor.Black);
        System.Console.Clear();
        System.Console.SetCursorPosition(0, 0);
    }
}