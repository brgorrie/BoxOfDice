using System.Security.Cryptography;

namespace Roll.DiceRolling;
public class DiceRoller : IDiceRoller
{
    public int[] RollDice(int rolls, int sides)
    {
        var results = new int[rolls];
        var bytes = new byte[4];
        using (var rng = RandomNumberGenerator.Create())
        {
            for (int i = 0; i < rolls; i++)
            {
                rng.GetBytes(bytes);
                int value = BitConverter.ToInt32(bytes, 0);
                // Ensure that the value is non-negative
                value = value >= 0 ? value : -value;
                // Map the value to a number between 1 and sides
                results[i] = (value % sides) + 1;
            }
        }
        return results;
    }

}
