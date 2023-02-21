// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

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
