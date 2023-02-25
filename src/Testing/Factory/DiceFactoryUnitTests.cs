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

using Roll.Factory;
using Roll.Model;

namespace Testing.Factory;

public class DiceFactoryUnitTests
{

    [Fact]
    public void Create_WithSides_ReturnsDiceWithCorrectSides()
    {
        // Arrange
        IDiceFactory factory = new DiceFactory();
        int sides = 10;

        // Act
        IDice dice = factory.Create(sides);

        // Assert
        Assert.Equal(sides, dice.Sides);
    }

    [Fact]
    public void Create_WithoutSides_ReturnsDiceWithSixSides()
    {
        // Arrange
        IDiceFactory factory = new DiceFactory();

        // Act
        IDice dice = factory.Create();

        // Assert
        Assert.Equal(6, dice.Sides);
    }

}
