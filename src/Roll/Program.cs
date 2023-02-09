namespace Roll;
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            if (!String.IsNullOrWhiteSpace(args[0]) && args[0].ToLower().Equals("1d6"))
            {
                Console.WriteLine("Result:");
            }
            else
            {
                Console.WriteLine("Invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.");
            }
        }
        else
        {
            Console.WriteLine("No parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.");
        }
    }
}
