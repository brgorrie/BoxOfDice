namespace Testing;

public class ProgramUnitTests
{
    [Fact]
    public void MainNoParametersTest()
    {

        var output = new StringWriter();
        Console.SetOut(output);

        Roll.Program.Main(Array.Empty<string>());

        var expectedValue = "No parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, output.ToString());

    }

    [Fact]
    public void MainInvalidParametersTest()
    {

        var output = new StringWriter();
        Console.SetOut(output);

        Roll.Program.Main(new string[]{"invalid parameter"});

        var expectedValue = "Invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, output.ToString());

    }

    [Fact]
    public void MainEmptyStringInvalidParametersTest()
    {

        var output = new StringWriter();
        Console.SetOut(output);

        Roll.Program.Main(new string[] { "" });

        var expectedValue = "Invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, output.ToString());

    }

    [Fact]
    public void MainWhiteSpaceInvalidParametersTest()
    {

        var output = new StringWriter();
        Console.SetOut(output);

        Roll.Program.Main(new string[] { "      " });

        var expectedValue = "Invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, output.ToString());

    }

    [Fact]
    public void MainRoll1D6Test()
    {

        var firstResult = CallProgramMain(new string[] { "1D6" });

        var regularExpression = "Result: [1-6]";

        Assert.Matches(regularExpression, firstResult);

    }

    private static string CallProgramMain(string[] args)
    {
        var output = new StringWriter();
        Console.SetOut(output);
        Roll.Program.Main(args);
        return output.ToString();
    }
}
