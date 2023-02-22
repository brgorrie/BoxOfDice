using System.Security.Cryptography;
using Roll.Factory;
using Roll.Model;

namespace Roll.DiceRolling;
public class DiceRoller : IDiceRoller
{

    private readonly IDiceFactory _diceFactory;

    public DiceRoller(IDiceFactory diceFactory)
    {
        _diceFactory = diceFactory;
    }

    public int[] RollDice(int rolls, int sides)
    {
        var results = new int[rolls];

        IDice dice = _diceFactory.Create(sides);

        for (int i = 0; i < rolls; i++)
        {
            results[i] = dice.Roll();
        }

        return results;
    }

}
