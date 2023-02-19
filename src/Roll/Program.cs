using Roll.DiceRolling;
using Roll.InputValidation;
using Roll.OutputPrinting;

namespace Roll;
public class Program
{

    private readonly IInputValidator _inputValidator;
    private readonly IDiceRoller _diceRoller;
    private readonly IOutputPrinter _outputPrinter;

    public Program(IInputValidator inputValidator, IDiceRoller diceRoller, IOutputPrinter outputPrinter)
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
