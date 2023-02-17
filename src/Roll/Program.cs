using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Roll;
public class Program
{
    public static void Main(string[] args)
    {

        var successfullRoll = false;

        if ( args.Length == 1 && !String.IsNullOrWhiteSpace(args[0]))
        {    

            if (!String.IsNullOrWhiteSpace(args[0]) )
            {
                var pattern = "^(\\d+)(d)(\\d+)$";
                var match = Regex.Match(args[0], pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    var rolls = int.Parse(match.Groups[1].Value);
                    var sides = int.Parse(match.Groups[3].Value);

                    int[] results = RollDice(CreateRandom(), rolls, sides);

                    Console.WriteLine($"UUID: {Guid.NewGuid().ToString()}");
                    Console.WriteLine($"Result for 1D{sides}: 1");
                    Console.WriteLine("Individual Results: " + string.Join(", ", results));
                    Console.WriteLine("Average: " + results.Average());
                    Console.WriteLine("Total: " + results.Sum());

                    successfullRoll = true;
                }

            }
        }

        if( !successfullRoll )
        {
            Console.WriteLine("Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.");
        }
    }

    private static Random CreateRandom()
    {
        var seed = new byte[sizeof(int)];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(seed);
        }
        return new Random(BitConverter.ToInt32(seed, 0));
    }

    private static int[] RollDice(Random random, int rolls, int sides)
    {
        // Roll the specified number of dice with the specified number of sides
        var results = new int[rolls];
        for (int i = 0; i < rolls; i++)
        {
            results[i] = random.Next(1, sides + 1);
        }
        return results;
    }

}
