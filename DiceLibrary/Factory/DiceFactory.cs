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

public class DiceFactory : IDiceFactory
{

    private readonly int _defaultSides;

    public DiceFactory(int defaultSides = 6)
    {
        _defaultSides = defaultSides;
    }

    public IDice Create(int sides)
    {
        return new Dice(sides);
    }

    public IDice Create()
    {
        return new Dice(_defaultSides);
    }

}
