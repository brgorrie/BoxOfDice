// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll.DiceRolling;

namespace Testing.DiceRolling;
public class DiceRollerUnitTests
{
    private readonly IDiceRoller _diceRoller;

    public DiceRollerUnitTests()
    {
        _diceRoller = new DiceRoller();
    }

    [Fact]
    public void RollDice_ReturnsCorrectNumberOfResults()
    {
        // Arrange
        int rolls = 10;
        int sides = 6;

        // Act
        var results = _diceRoller.RollDice(rolls, sides);

        // Assert
        Assert.Equal(rolls, results.Length);
    }

    [Theory]
    [InlineData(1, 6)]
    [InlineData(2, 6)]
    [InlineData(10, 6)]
    [InlineData(1, 8)]
    [InlineData(2, 8)]
    [InlineData(10, 8)]
    [InlineData(1, 20)]
    [InlineData(2, 20)]
    [InlineData(10, 20)]
    [InlineData(1, 100)]
    [InlineData(2, 100)]
    [InlineData(10, 100)]
    public void RollDice_ReturnsResultsInValidRange(int rolls, int sides)
    {
        // Arrange
        int minValue = 1;
        int maxValue = sides;

        // Act
        var results = _diceRoller.RollDice(rolls, sides);

        // Assert
        foreach (var result in results)
        {
            Assert.InRange(result, minValue, maxValue);
        }
    }

}
