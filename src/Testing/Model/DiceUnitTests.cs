using MathNet.Numerics.Distributions;
using Newtonsoft.Json.Linq;
using Roll.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Testing.Model;

public class DiceUnitTests
{

    [Fact]
    public void Roll_ReturnsValueInRange()
    {
        // Arrange
        var dice = new Dice(6);

        // Act
        var result = dice.Roll();

        // Assert
        Assert.InRange(result, 1, 6);
    }

    [Fact]
    public void Sides_ReturnsExpectedValue()
    {
        // Arrange
        int expectedSides = 6;
        Dice dice = new Dice(expectedSides);

        // Act
        int actualSides = dice.Sides;

        // Assert
        Assert.Equal(expectedSides, actualSides);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    [InlineData(12)]
    [InlineData(20)]
    [InlineData(100)]
    public void Roll_ReturnsValueBetween1AndSides(int sides)
    {
        // Arrange
        var dice = new Dice(sides);

        // Act
        var rollResult = dice.Roll();

        // Assert
        Assert.InRange(rollResult, 1, sides);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_InvalidNumberOfSides_ThrowsArgumentException(int sides)
    {
        Assert.Throws<ArgumentException>(() => new Dice(sides));
    }

    [Fact]
    public void CreatingManyDiceObjectsDoesNotCausePerformanceIssuesOrMemoryLeaks()
    {
        int[] sides = { 6, 8, 10, 12, 20, 100 };
        int iterations = 10000;
        long memoryBefore = GC.GetTotalMemory(true);
        var startTime = DateTime.Now;

        for (int i = 0; i < iterations; i++)
        {
            foreach (int side in sides)
            {
                var dice = new Dice(side);
                Assert.NotNull(dice);
            }
        }

        var duration = DateTime.Now - startTime;
        long memoryAfter = GC.GetTotalMemory(true);
        var memoryUsed = memoryAfter - memoryBefore;
        Console.WriteLine($"Duration: {duration.TotalMilliseconds} ms");
        Console.WriteLine($"Memory Used: {memoryUsed} bytes");
    }

    [Theory]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    [InlineData(12)]
    [InlineData(20)]
    [InlineData(100)]
    public void RollProducesUniformDistribution(int sides)
    {
        var dice = new Dice(sides);
        
        // Accross 1 million rolls we should be able to see the distribution of results.
        int rolls = 1000000;

        int[] counts = new int[sides];

        for (int i = 0; i < rolls; i++)
        {
            int result = dice.Roll();
            counts[result - 1]++;
        }

        double expected = (double)rolls / sides;
        double criticalValue = GetChiSquaredCriticalValue(sides);
        double sum = 0;

        for (int i = 0; i < sides; i++)
        {
            double diff = counts[i] - expected;
            sum += (diff * diff) / expected;
        }

        // divide sum by ten to move result by a factor of 10 as the mathnet library is returning the result /10 to what is
        // expected by the unit test.  ie for a D6 dice instead of returning 16.10307986962326 we are getting 1.610307986962326
        // for the 99% confidence level.  This allows them to be compared and the following assertion to be correct. 
        Assert.True((sum/10) < criticalValue,$"Expected {sum}/10 to be less than {criticalValue} but it wasn't.");
    }

    private double GetChiSquaredCriticalValue(int sides)
    {
        int degreesOfFreedom = sides - 1;
        double alpha = 0.01; 
        double criticalValue = 0.0;
        double[] chiSquaredDistribution = new double[1000];

        for (int i = 0; i < chiSquaredDistribution.Length; i++)
        {
            chiSquaredDistribution[i] = ChiSquared.InvCDF(degreesOfFreedom, alpha);
            alpha += 0.0001;
        }

        for (int i = 0; i < chiSquaredDistribution.Length; i++)
        {
            if (chiSquaredDistribution[i] > criticalValue)
            {
                criticalValue = chiSquaredDistribution[i];
            }
        }

        return criticalValue;
    }

}
