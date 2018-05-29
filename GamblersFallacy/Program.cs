using Newtonsoft.Json;
using RestSharp;
using System;

namespace GamblersFallacy
{

    class Program
    {
        public static Player Player { get; set; }

        static void Main(string[] args)
        {

            Init();

            MainMenu();

            Console.ReadLine();
        }

        private static void MainMenu()
        {
            PrintPlayerInfo();

            Console.ForegroundColor = ConsoleColor.DarkGray; ;

            Console.WriteLine("1. Play single games");
            Console.WriteLine("2. Multiple spins simulation");
            Console.WriteLine("3. Batch simulation");

            var input = InputService.AcceptInputRange(3);

            switch (input)
            {
                case 1:
                    SingleRouletteGames();
                    break;
                case 2:                
                    MultipleSpinsSimulation();
                    break;
                case 3:
                    BatchSimualtion();
                    break; 
                default:
                    MainMenu();
                    break;
            }

            MainMenu();
        }

        private static void BatchSimualtion()
        {

            var batch = new BatchSimualtion(1000, new MultipleSpinsSimulation(100, 100));
        }

        private static void MultipleSpinsSimulation()
        {
            Console.WriteLine("How many spins? (enter non-number to go back to main menu) ");

            var input = InputService.AcceptNumericInput(1, 100000);
            if (input < 1)
            {
                MainMenu();
            }
            else
            {
                var simulation = new MultipleSpinsSimulation(input, Player.Money);
                var result = simulation.DoMultipleSpins();
                result.Print();

                ResetConsoleColor();
            }
        }

        private static void SingleRouletteGames()
        {
            PrintPlayerInfo();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Bet on RED");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("2. Bet on BLACK");

            ResetConsoleColor();
            var input = InputService.AcceptInputRange(3);

            bool betOnRed;

            betOnRed = input == 1 ? true : false;

            var betResult = new SingleSpinGame().PlaySingleSpin(betOnRed);

            PrintPlayerInfo();

            if (betResult == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You won!!!");
                Player.Money += 10;
                Console.WriteLine(betResult);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You loose!!!");
                Player.Money -= 10;
                Console.WriteLine(betResult);

            }
            
            Console.ReadKey();
            SingleRouletteGames();
        }


        private static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        private static void PrintPlayerInfo()
        {
            Console.Clear();

            if (Player != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("*************************");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Money {Player.Money}");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("*************************");

            }
        }
        private static void Init()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Beep(100, 200);
            ResetConsoleColor();

            Player = new Player()
            {
                Money = 100
            };
        }
    }
}
