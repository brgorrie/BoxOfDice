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

using System.Security.Cryptography;

namespace Roll.Model;

public class Dice : IDice
{
    public int Sides { get; }

    public Dice(int sides)
    {
        if (sides < 1)
        {
            throw new ArgumentException($"The number of sides passed into the constructor isn't 1 or greater: {sides}");
        }
        Sides = sides;
    }

    public int Roll()
    {
        var bytes = new byte[4];
        using (var rng = RandomNumberGenerator.Create())
        {
                rng.GetBytes(bytes);
                int value = BitConverter.ToInt32(bytes, 0);
                // Ensure that the value is non-negative
                value = value >= 0 ? value : -value;
                // Map the value to a number between 1 and sides
                return (value % Sides) + 1;
        }
    }

}
