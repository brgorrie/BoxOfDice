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
public class OutputPrinter : IOutputPrinter
{

    public void PrintResults(int[] results, int sides)
    {
        if( results == null ) 
        {
            throw new ArgumentNullException(nameof(results), "Results array cannot be null or empty");
        }

        if (results.Length == 0) 
        {
            throw new ArgumentException("Results array cannot be null or empty");
        }

        if (sides == 0)
        {
            throw new ArgumentException("Sides value must be greater than 0");
        }

        Console.WriteLine($"UUID: {Guid.NewGuid().ToString()}");
        Console.WriteLine("Individual Results: " + string.Join(", ", results));
        Array.Sort(results);
        Console.WriteLine("Sorted Results:" + string.Join(", ", results));
        Console.WriteLine("Min:" + results.Min());
        Console.WriteLine("Max:" + results.Max());
        Console.WriteLine("Average: " + results.Average());
        Console.WriteLine("Total: " + results.Sum());
    }

    public void PrintArgumentException(ArgumentException argumentException)
    {
        Console.WriteLine(argumentException.Message);
        Console.WriteLine("Either no parameters or invalid parameters were provided, please specify a dice roll ie 1d6 or 1D6 or put -? for help.");

    }

}
