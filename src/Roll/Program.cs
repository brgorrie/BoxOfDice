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
