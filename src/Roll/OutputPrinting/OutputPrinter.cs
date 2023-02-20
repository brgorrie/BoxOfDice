
namespace Roll.OutputPrinting;
public class OutputPrinter : IOutputPrinter
{

    public void PrintResults(int[] results, int sides)
    {
        if( results == null ) 
        {
            throw new ArgumentNullException(nameof(results), "Results array cannot be null or empty");
        }

        if (results.Length == 0) 
        {
            throw new ArgumentException("Results array cannot be null or empty");
        }

        if (sides == 0)
        {
            throw new ArgumentException("Sides value must be greater than 0");
        }

        Console.WriteLine($"UUID: {Guid.NewGuid().ToString()}");
        Console.WriteLine("Individual Results: " + string.Join(", ", results));
        Console.WriteLine("Average: " + results.Average());
        Console.WriteLine("Total: " + results.Sum());
    }

    public void PrintArgumentException(ArgumentException argumentException)
    {
        Console.WriteLine(argumentException.Message);
        Console.WriteLine("Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.");

    }

}
