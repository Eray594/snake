using FluentAssertions;
using NUnit.Framework;
using Snake.Core.Entities;
using Snake.Core.Options;
using Snake.Core.PlayGround;

namespace Snake.UnitTest;

public class SnakeTest
{
    [Test]
    public void ShouldReturnTrue_WhenCollidedWithFood()
    {
        //Arrange
        var snake = new Core.Entities.Snake(12, 5);
        var food = new Food(row: 12, column: 5, value: 1);
        
        //Act
        var result = snake.HasCollisionWith(food);
        
        //Assert
        result.Should().Be(true);
    }

    [Test]
    public void ShouldReturnFalse_WhenIsNotCollidedWithFood()
    {
        //Arrange
        var snake = new Core.Entities.Snake(row: 12, column: 5);
        var food = new Food(row: 4, column: 1, value: 1);
        
        //Act
        var result = snake.HasCollisionWith(food);
        
        //Assert
        result.Should().Be(false);
    }

    [Test]
    public void ShouldReturnTrue_WhenPartIsHead()
    {
        //Arrange
        var snake = new Core.Entities.Snake(row: 12, column: 5);
        var head = new SnakePart(row: 12, column: 5);
        
        //Act
        var result = snake.IsHead(head);
        
        //Assert
        result.Should().Be(true);
    }

    [Test]
    public void ShouldReturnFalse_WhenPartIsNotHead()
    {
        //Arrange
        var snake = new Core.Entities.Snake(row: 12, column: 5);
        var head = new SnakePart(row: 2, column: 5);
        
        //Act
        var result = snake.IsHead(head);
        
        //Assert
        result.Should().Be(false);
    }

    [Test]
    public void TheLenghtOfTheSnakeShouldBeThree_WhenGrowIsCalled()
    {
        //Arrange
        var snake = new Core.Entities.Snake(row: 12, column: 5);
        
        //Act
        snake.Grow(1);
        
        //Assert
        snake.Body.Count.Should().Be(3);
    }

    [Test]
    public void TheDirectionShouldBeDown_WhenChangeDirectionIsCalled()
    {
        //Arrange
        var snake = new Core.Entities.Snake(row: 12, column: 5);
        
        //Act
        snake.ChangeDirection(Direction.Down);
        
        //Assert
        snake.CurrentDirection.Should().Be(Direction.Down);
    }
}