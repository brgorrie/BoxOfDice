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

using DiceLibrary.Model;

namespace DiceLibrary.Factory;

/// <summary>
/// Represents a factory for creating instances of the <see cref="IDice"/> interface.
/// </summary>
public interface IDiceFactory
{

    /// <summary>
    /// Creates a new instance of the <see cref="IDice"/> interface with the specified number of sides.
    /// </summary>
    /// <param name="sides">The number of sides for the new dice.</param>
    /// <returns>A new instance of the <see cref="IDice"/> interface.</returns>
    IDice Create(int sides);

    /// <summary>
    /// Creates a new instance of the <see cref="IDice"/> interface with the default number of sides.
    /// </summary>
    /// <returns>A new instance of the <see cref="IDice"/> interface.</returns>
    IDice Create();

}
