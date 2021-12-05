using System;
using static ConsoleApp1.Ceasar;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ceasar ca = new Ceasar();
            Console.WriteLine("================Program started================ ");
            Console.WriteLine("1. After typing something it will give result what it would look like in Ceasar cipher");
            Console.WriteLine("2. !lshift to change ciphers shift in positions to the left");
            Console.WriteLine("3. !rshift to change ciphers shift in positions to the right");
            Console.WriteLine("4. !quit to exit");

            runProgram(ca, true);
        }
        /// <summary>
        /// Runs while loop, ant takes inputs from console.
        /// </summary>
        /// <param name="ca">Ceasar object</param>
        /// <param name="run">Start program loop</param>
        public static void runProgram(Ceasar ca, bool run)
        {
            string input = "";
            while (run)
            {
                Console.Write(">");
                input = Console.ReadLine();
                switch (input)
                {
                    case "!quit":
                        run = false;
                        break;
                    case "!lshift":
                        executeShift(ca, true);
                        break;
                    case "!rshift":
                        executeShift(ca, false);
                        break;
                    default:
                        Console.WriteLine("Cipher: {0}", ca.Cipher(input));
                        break;
                }
            }
        }
        /// <summary>
        /// Asks for shift position, and executes correct shift
        /// </summary>
        /// <param name="ca">Ceasar object</param>
        /// <param name="left">Is this shift left</param>
        public static void executeShift(Ceasar ca, bool left)
        {
            int number = 0;
            string input = "";
            Console.Write("Please enter a number between 1 and 26: ");
            input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine("Input must be an integer or to stop type !q");
                input = Console.ReadLine();
                if (input == "!q")
                {
                    break;
                }
            }
            if (input != "!q" && left) ca.SetShift(number, left);
            else if (input != "!q" && !left) ca.SetShift(number, left);
        }
    }
}
