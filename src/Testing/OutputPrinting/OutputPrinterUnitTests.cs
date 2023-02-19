// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll.OutputPrinting;

namespace Testing.OutputPrinting;
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
        
        Assert.Contains($"Result for 1D{expectedSides}: 1", consoleOutput);
        Assert.Contains("Individual Results: " + string.Join(", ", expectedResults), consoleOutput);
        Assert.Contains($"Average: {expectedAverage}", consoleOutput);
        Assert.Contains($"Total: {expectedTotal}", consoleOutput);
    }

    [Fact]
    public void PrintResults_ThrowsArgumentException_WhenInvalidArrayProvided()
    {
        // Arrange
        int[] invalidResults = null;
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

    [Fact]
    public void PrintArgumentException_ThrowsExceptionWhenCalledWithNull()
    {
        // Arrange
        ArgumentException argumentException = null;
        var outputPrinter = new OutputPrinter();

        // Act and Assert
        Assert.Throws<NullReferenceException>(() => outputPrinter.PrintArgumentException(argumentException));
    }

}
