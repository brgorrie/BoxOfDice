// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Roll.Factory;
using Roll.Model;

namespace Testing.Factory;

public class DiceFactoryUnitTests
{

    [Fact]
    public void Create_WithSides_ReturnsDiceWithCorrectSides()
    {
        // Arrange
        IDiceFactory factory = new DiceFactory();
        int sides = 10;

        // Act
        IDice dice = factory.Create(sides);

        // Assert
        Assert.Equal(sides, dice.Sides);
    }

    [Fact]
    public void Create_WithoutSides_ReturnsDiceWithSixSides()
    {
        // Arrange
        IDiceFactory factory = new DiceFactory();

        // Act
        IDice dice = factory.Create();

        // Assert
        Assert.Equal(6, dice.Sides);
    }

}
