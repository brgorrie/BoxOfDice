using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Roll.InputValidation;

namespace Roll;
public class Program
{

    private readonly InputValidator _inputValidator;

    public Program(InputValidator inputValidator)
    {
        _inputValidator = inputValidator;
    }

    public void Run(string[] args)
    {
        try
        {
            var (rolls, sides) = _inputValidator.ParseInput(args);

            int[] results = RollDice(CreateRandom(), rolls, sides);

            Console.WriteLine($"UUID: {Guid.NewGuid().ToString()}");
            Console.WriteLine($"Result for 1D{sides}: 1");
            Console.WriteLine("Individual Results: " + string.Join(", ", results));
            Console.WriteLine("Average: " + results.Average());
            Console.WriteLine("Total: " + results.Sum());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.");
        }
    }

    private int[] RollDice(Random random, int rolls, int sides)
    {
        // Roll the specified number of dice with the specified number of sides
        var results = new int[rolls];
        for (int i = 0; i < rolls; i++)
        {
            results[i] = random.Next(1, sides + 1);
        }
        return results;
    }

    private Random CreateRandom()
    {
        var seed = new byte[sizeof(int)];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(seed);
        }
        return new Random(BitConverter.ToInt32(seed, 0));
    }

    public static void Main(string[] args)
    {

        var program = new Program(new InputValidator());
        program.Run(args);
    }

}
