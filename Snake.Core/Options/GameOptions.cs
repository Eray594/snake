namespace Snake.Core.Options;

public record GameOptions(int Size, int Interval,
    int ObstacleAmount, (int row, int column) StartPosition);