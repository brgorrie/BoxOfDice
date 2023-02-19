// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Roll.DiceRolling;

public interface IDiceRoller
{
    int[] RollDice(int rolls, int sides);
    int[] RollDice(Random random, int rolls, int sides);
    Random CreateRandom();
}
