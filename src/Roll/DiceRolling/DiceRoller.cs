using System.Security.Cryptography;

namespace Roll.DiceRolling;
public class DiceRoller
{

    public int[] RollDice(int rolls, int sides)
    {
        return RollDice(CreateRandom(), rolls, sides);
    }

    public int[] RollDice(Random random, int rolls, int sides)
    {
        // Roll the specified number of dice with the specified number of sides
        var results = new int[rolls];
        for (int i = 0; i < rolls; i++)
        {
            results[i] = random.Next(1, sides + 1);
        }
        return results;
    }

    public Random CreateRandom()
    {
        var seed = new byte[sizeof(int)];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(seed);
        }
        return new Random(BitConverter.ToInt32(seed, 0));
    }

}
