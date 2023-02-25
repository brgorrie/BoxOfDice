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

namespace Roll.InputValidation;

public interface IInputValidator
{
    /// <summary>
    /// Parses the first argument in the array and returns the number of rolls and number of sides values.
    /// Throws an exception if the input is invalid in that it:
    ///     * doesn't have the correct number of arguments
    ///     * there is one argument but it is an empty string
    ///     * the argument isn't of the 1d6 or 2D12 style of specifying die rolls. 
    /// </summary>
    (int Rolls, int Sides) ParseInput(string[] args);
}
