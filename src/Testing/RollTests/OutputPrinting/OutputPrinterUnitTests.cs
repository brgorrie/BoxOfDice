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

using Roll.OutputPrinting;

namespace Testing.RollTests.OutputPrinting;
public class OutputPrinterUnitTests
{
    [Fact]
    public void PrintResults_ValidInput_PrintsCorrectlyToConsole()
    {
        // Arrange
        var outputPrinter = new OutputPrinter();
        var expectedSides = 6;
        var expectedResults = new int[] { 1, 2, 3, 4, 5, 6 };
        var expectedAverage = expectedResults.Average();
        var expectedTotal = expectedResults.Sum();

        // Act
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);
        outputPrinter.PrintResults(expectedResults, expectedSides);
        Console.SetOut(originalOutput);

        // Assert
        var consoleOutput = output.ToString();
        
        Assert.Contains("Individual Results: " + string.Join(", ", expectedResults), consoleOutput);
        Assert.Contains($"Average: {expectedAverage}", consoleOutput);
        Assert.Contains($"Total: {expectedTotal}", consoleOutput);
    }

    [Fact]
    public void PrintResults_ThrowsArgumentException_WhenInvalidArrayProvided()
    {
        // Arrange
        int[] invalidResults = new int[]{};
        int sides = 6;
        var outputPrinter = new OutputPrinter();

        // Act and Assert
        var ex = Assert.Throws<ArgumentNullException>(() => outputPrinter.PrintResults(invalidResults, sides));
        Assert.Contains("Results array cannot be null or empty", ex.Message);
    }

    [Fact]
    public void PrintResults_ThrowsArgumentException_WhenInvalidSidesProvided()
    {
        // Arrange
        int[] results = new int[] { 1, 2, 3 };
        int invalidSides = 0;
        var outputPrinter = new OutputPrinter();

        // Act and Assert
        var ex = Assert.Throws<ArgumentException>(() => outputPrinter.PrintResults(results, invalidSides));
        Assert.Equal("Sides value must be greater than 0", ex.Message);
    }

    [Fact]
    public void PrintArgumentException_PrintsExceptionMessageCorrectly()
    {
        // Arrange
        var expectedMessage = "Invalid parameters were provided";
        var argumentException = new ArgumentException(expectedMessage);
        var outputPrinter = new OutputPrinter();

        // Act
        var output = new StringWriter();
        var originalOutput = Console.Out;

        Console.SetOut(output);
        outputPrinter.PrintArgumentException(argumentException);
        Console.SetOut(originalOutput);

        // Assert
        var consoleOutput = output.ToString();

        Assert.Contains($"{expectedMessage}",
            consoleOutput);
        Assert.Contains($"Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.",
            consoleOutput);
    }

}
