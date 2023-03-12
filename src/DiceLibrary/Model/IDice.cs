﻿// Copyright 2023 Brian Gorrie
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

namespace DiceLibrary.Model;

/// <summary>
/// Defines the interface for a single dice with a specified number of sides.
/// </summary>
public interface IDice
{

    /// <summary>
    /// Gets the number of sides on the dice.
    /// </summary>
    int Sides { get; }

    /// <summary>
    /// Rolls the dice and returns the result.
    /// </summary>
    /// <returns>A random integer between 1 and the number of sides on the dice.</returns>
    int Roll();
}
