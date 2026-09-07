using Snake.Core.PlayGround;

namespace Snake.Core;

public interface IUserInterface
{ 
    void Render(ICell[,] field);
    void GameOver();
}