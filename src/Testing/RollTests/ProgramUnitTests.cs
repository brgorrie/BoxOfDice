// Copyright 2023 Brian Gorrie
// 
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Roll;

namespace Testing.RollTests;

public class ProgramUnitTests
{
    [Fact]
    public void Main_NoParametersTest()
    {

        var expectedValue = "Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(Array.Empty<string>()));

    }

    [Fact]
    public void Main_InvalidParametersTest()
    {

        var expectedValue = "Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(new string[] { "invalid parameter" }));

    }

    [Fact]
    public void Main_EmptyString_InvalidParametersTest()
    {

        var expectedValue = "Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(new string[] { "" }));

    }

    [Fact]
    public void Main_WhiteSpace_InvalidParametersTest()
    {

        var expectedValue = "Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.";

        Assert.Contains(expectedValue, CallProgramMain(new string[] { "      " }));

    }

    [Fact]
    public void Main_Roll1D6Test()
    {

        var output = CallProgramMain(new string[] { "1D6" });

        var regularExpression = "Individual Results: [1-6]";

        Assert.Matches(regularExpression, output);

    }

    [Fact]
    public void Main_Roll1D6_CheckDifferentResultsTest()
    {

        var diceRoll1 = CallProgramMain(new string[] { "1D6" });
        var diceRoll2 = CallProgramMain(new string[] { "1D6" });

        var regularExpression = "Individual Results: [1-6]";

        Assert.Matches(regularExpression, diceRoll1);
        Assert.Matches(regularExpression, diceRoll2);

        // This forces the results to be different. While this looks like a valid test it isn't valid as you can roll a d6 twice and
        // get the same value.
        Assert.NotEqual(diceRoll1, diceRoll2);

    }

    /*
     * Utility function to call the main method and capture console output for the unit tests.
     */
    private static string CallProgramMain(string[] args)
    {
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);
        Roll.Program.Main(args);
        Console.SetOut(originalOutput);
        return output.ToString();
    }

}
