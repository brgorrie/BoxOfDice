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

using DiceLibrary.Factory;

namespace DiceLibrary.DiceRolling;

/// <summary>
/// Provides a mechanism for rolling dice.
/// </summary>
public class DiceRoller : IDiceRoller
{

    private readonly IDiceFactory _diceFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="DiceRoller"/> class.
    /// </summary>
    /// <param name="diceFactory">The <see cref="IDiceFactory"/> used to create new dice.</param>
    public DiceRoller(IDiceFactory diceFactory)
    {
        _diceFactory = diceFactory;
    }

    /// <summary>
    /// Rolls a specified number of dice with a specified number of sides.
    /// </summary>
    /// <param name="rolls">The number of dice rolls to perform.</param>
    /// <param name="sides">The number of sides on each die.</param>
    /// <returns>An array of integers representing the results of each roll.</returns>
    /// <exception cref="ArgumentException">Thrown when either the number of rolls or the number of sides is less than 1.</exception>
    public int[] RollDice(int rolls, int sides)
    {

        if (rolls < 1)
        {
            throw new ArgumentException("The number of rolls must be 1 or more.", nameof(rolls));
        }

        if (sides < 1)
        {
            throw new ArgumentException("The number of sides must be 1 or more.", nameof(sides));
        }

        var results = new int[rolls];

        var dice = _diceFactory.Create(sides);

        for (var i = 0; i < rolls; i++)
        {
            results[i] = dice.Roll();
        }

        return results;
    }

}

