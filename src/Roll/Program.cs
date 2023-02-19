using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Roll.DiceRolling;
using Roll.InputValidation;
using Roll.OutputPrinting;

namespace Roll;
public class Program
{

    private readonly InputValidator _inputValidator;
    private readonly DiceRoller _diceRoller;
    private readonly OutputPrinter _outputPrinter;

    public Program(InputValidator inputValidator, DiceRoller diceRoller, OutputPrinter outputPrinter)
    {
        _inputValidator = inputValidator;
        _diceRoller = diceRoller;
        _outputPrinter = outputPrinter;
    }

    public void Run(string[] args)
    {


        try
        {
            var (rolls, sides) = _inputValidator.ParseInput(args);

            _outputPrinter.PrintResults(_diceRoller.RollDice(rolls, sides), sides);

        }
        catch (ArgumentException ex)
        {
            _outputPrinter.PrintArgumentException(ex);
        }
    }

    public static void Main(string[] args)
    {

        var program = new Program(new InputValidator(), new DiceRoller(), new OutputPrinter());
        program.Run(args);

    }

}
