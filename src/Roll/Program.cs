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

using Autofac;
using Roll.DiceRolling;
using Roll.Factory;
using Roll.InputValidation;
using Roll.OutputPrinting;

namespace Roll
{
    public class Program
    {
        private readonly IInputValidator _inputValidator;
        private readonly IDiceRoller _diceRoller;
        private readonly IOutputPrinter _outputPrinter;

        public Program(IInputValidator inputValidator, IDiceRoller diceRoller, IOutputPrinter outputPrinter)
        {
            _inputValidator = inputValidator;
            _diceRoller = diceRoller;
            _outputPrinter = outputPrinter;
        }

        public void Run(string[] args)
        {
            try
            {
                var (rolls, sides) = _inputValidator.ParseInput(args);
                _outputPrinter.PrintResults(_diceRoller.RollDice(rolls, sides), sides);
            }
            catch (ArgumentException ex)
            {
                _outputPrinter.PrintArgumentException(ex);
            }
        }

        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<InputValidator>().As<IInputValidator>();
            builder.RegisterType<DiceFactory>().As<IDiceFactory>();
            builder.RegisterType<DiceRoller>().As<IDiceRoller>();
            builder.RegisterType<OutputPrinter>().As<IOutputPrinter>();
            builder.RegisterType<Program>();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var program = scope.Resolve<Program>();
                program.Run(args);
            }
        }
    }
}
