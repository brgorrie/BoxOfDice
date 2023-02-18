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

    [Fact]
    public void RollDice_ReturnsValidResults()
    {
        // Arrange
        var roller = new DiceRoller();
        var random = roller.CreateRandom();
        var rolls = 3;
        var sides = 6;

        // Act
        var results = roller.RollDice(random, rolls, sides);

        // Assert
        Assert.Equal(rolls, results.Length);
        Assert.All(results, r => Assert.InRange(r, 1, sides));
    }

    [Fact]
    public void CreateRandom_ReturnsValidRandom()
    {
        // Arrange
        var roller = new DiceRoller();

        // Act
        var random = roller.CreateRandom();

        // Assert
        Assert.IsType<Random>(random);
    }

}
