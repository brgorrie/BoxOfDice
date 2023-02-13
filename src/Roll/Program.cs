using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

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
                    int[] results = RollDice(rolls, sides);

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

    private static int[] RollDice(int dice, int sides)
    {
        var random = new Random();

        // Roll the specified number of dice with the specified number of sides
        var rolls = Enumerable.Range(0, dice)
            .Select(d => random.Next(1, sides + 1))
            .ToArray();

        return rolls;
    }

}
