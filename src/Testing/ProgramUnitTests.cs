namespace Testing;

public class ProgramUnitTests
{
    [Fact]
    public void MainNoParametersTest()
    {

        var expectedValue = "No parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(Array.Empty<string>()));

    }

    [Fact]
    public void MainInvalidParametersTest()
    {

        var expectedValue = "Invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(new string[] { "invalid parameter" }));

    }

    [Fact]
    public void MainEmptyStringInvalidParametersTest()
    {

        var expectedValue = "Invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(new string[] { "" }));

    }

    [Fact]
    public void MainWhiteSpaceInvalidParametersTest()
    {

        var expectedValue = "Invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(new string[] { "      " }));

    }

    [Fact]
    public void MainRoll1D6Test()
    {

        var diceRoll = CallProgramMain(new string[] { "1D6" });

        var regularExpression = "Result: [1-6]";

        Assert.Matches(regularExpression, diceRoll);

    }

    [Fact]
    public void MainRoll1D6CheckDifferentResultsTest()
    {

        var diceRoll1 = CallProgramMain(new string[] { "1D6" });
        var diceRoll2 = CallProgramMain(new string[] { "1D6" });

        var regularExpression = "Result: [1-6]";

        Assert.Matches(regularExpression, diceRoll1);
        Assert.Matches(regularExpression, diceRoll2);

        // This forces the results to be different. 
        Assert.NotEqual(diceRoll1, diceRoll2);

    }

    private static string CallProgramMain(string[] args)
    {
        var output = new StringWriter();
        Console.SetOut(output);
        Roll.Program.Main(args);
        return output.ToString();
    }
}
