// Copyright 2023 Brian Gorrie
// 
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll.DiceRolling;
using Roll.Factory;

namespace Testing.DiceRolling;
public class DiceRollerUnitTests
{

    [Fact]
    public void RollDice_ReturnsCorrectNumberOfResults()
    {
        // Arrange
        IDiceRoller diceRoller = new DiceRoller(new DiceFactory());
        int rolls = 10;
        int sides = 6;

        // Act
        var results = diceRoller.RollDice(rolls, sides);

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
        IDiceRoller diceRoller = new DiceRoller(new DiceFactory());
        int minValue = 1;
        int maxValue = sides;

        // Act
        var results = diceRoller.RollDice(rolls, sides);

        // Assert
        foreach (var result in results)
        {
            Assert.InRange(result, minValue, maxValue);
        }
    }

}
