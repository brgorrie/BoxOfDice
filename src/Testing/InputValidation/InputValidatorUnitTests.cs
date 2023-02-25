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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll.InputValidation;

namespace Testing.InputValidation;
public class InputValidatorUnitTests
{

    private readonly IInputValidator _inputValidator = new InputValidator();

    [Fact]
    public void ParseInput_ValidInput_ReturnsRollsAndSides()
    {
        // Arrange
        var input = new[] { "2d6" };

        // Act
        var (rolls, sides) = _inputValidator.ParseInput(input);

        // Assert
        Assert.Equal(2, rolls);
        Assert.Equal(6, sides);
    }

    [Theory]
    [InlineData("2d6", 2, 6)]
    [InlineData("1d20", 1, 20)]
    [InlineData("10d10", 10, 10)]
    public void ParseInput_ValidInput_ReturnsCorrectValues(string inputString, int expectedRolls, int expectedSides)
    {
        // Arrange
        var input = new[] { inputString };

        // Act
        var (rolls, sides) = _inputValidator.ParseInput(input);

        // Assert
        Assert.Equal(expectedRolls, rolls);
        Assert.Equal(expectedSides, sides);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("2 D 6")]
    [InlineData("d6")]
    [InlineData("2d")]
    [InlineData("2d6d8")]
    [InlineData("hello world")]
    public void ParseInput_InvalidInput_ThrowsArgumentException(string inputString)
    {
        // Arrange
        var input = new[] { inputString };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _inputValidator.ParseInput(input));
    }

}
