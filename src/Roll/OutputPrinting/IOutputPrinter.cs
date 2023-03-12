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

namespace Roll.OutputPrinting;

/// <summary>
/// Represents an object that can print the results of a dice roll to the console.
/// </summary>
public interface IOutputPrinter
{

    /// <summary>
    /// Prints the results of a dice roll to the console.
    /// </summary>
    /// <param name="results">The results of the dice roll.</param>
    /// <param name="sides">The number of sides on the dice that were rolled.</param>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="results"/> array is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown if the <paramref name="sides"/> value is 0.</exception>
    void PrintResults(int[] results, int sides);

    /// <summary>
    /// Prints an argument exception message to the console.
    /// </summary>
    /// <param name="argumentException">The argument exception to print.</param>
    void PrintArgumentException(ArgumentException argumentException);
}
