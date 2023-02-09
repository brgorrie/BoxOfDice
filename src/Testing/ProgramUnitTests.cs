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

}
