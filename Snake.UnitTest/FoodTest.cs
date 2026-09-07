using FluentAssertions;
using NUnit.Framework;
using Snake.Core.Entities;
using Snake.Core.PlayGround;

namespace Snake.UnitTest;

public class FoodTest
{
    [Test]
    public void ShouldReturnTrue_WhenIsCollidedWithCell()
    {
        //Arrange
        var food = new Food(row: 12, column: 6, value: 1);
        var cell = new Blank(row: 12, column: 6);

        //Act
        var result = food.HasCollisionWith(cell);

        //Assert
        result.Should().Be(true);
    }

    [Test]
    public void ShouldReturnFalse_WhenIsNotCollidedWithCell()
    {
        //Arrange
        var food = new Food(row: 12, column: 6, value: 1);

        //Act
        var cell = new Blank(row: 2, column: 3);
        var result = food.HasCollisionWith(cell);

        //Assert
        result.Should().Be(false);
    }
}