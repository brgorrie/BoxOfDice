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

namespace DiceLibrary.DiceRolling;

/// <summary>
/// Represents an object that can roll a specified number of dice with a specified number of sides.
/// </summary>
public interface IDiceRoller
{

    /// <summary>
    /// Rolls a specified number of dice with a specified number of sides.
    /// </summary>
    /// <param name="rolls">The number of dice rolls to perform.</param>
    /// <param name="sides">The number of sides on each die.</param>
    /// <returns>An array of integers representing the results of each roll.</returns>
    int[] RollDice(int rolls, int sides);

}

