using FluentAssertions;
using NUnit.Framework;
using Snake.Core.Entities;
using Snake.Core.PlayGround;

namespace Snake.UnitTest;

public class ObstacleTest
{
    [Test]
    public void ShouldReturnTrue_WhenIsCollidedWithCell()
    {
        //Arrange
        var obstacle = new Obstacle(row: 12, column: 6);
        var cell = new Blank(row: 12, column: 6);

        //Act
        var result = obstacle.HasCollisionWith(cell);

        //Assert
        result.Should().Be(true);
    }
    
    [Test]
    public void ShouldReturnFalse_WhenIsCollidedWithCell()
    {
        //Arrange
        var obstacle = new Obstacle(row: 12, column: 6);
        var cell = new Blank(row: 2, column: 3);

        //Act
        var result = obstacle.HasCollisionWith(cell);

        //Assert
        result.Should().Be(false);
    }
}