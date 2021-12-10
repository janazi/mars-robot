using System;

namespace MarsRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Robot management");

            var commandString = "FFRFLFLF";
            Console.WriteLine("Input plateau size  ex: 5x5");
            string plateau = Console.ReadLine();
            Console.WriteLine($"Input command to move ex: {commandString}");
            commandString = Console.ReadLine();

            var robot = new Robot(plateau);
            robot.Move(commandString);

            Console.ReadKey();
        }
    }
}
