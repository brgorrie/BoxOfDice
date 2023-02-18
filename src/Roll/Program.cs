using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Roll.DiceRolling;
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

            int[] results = new DiceRoller().RollDice(rolls, sides);

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

    public static void Main(string[] args)
    {

        var program = new Program(new InputValidator());
        program.Run(args);
    }

}
