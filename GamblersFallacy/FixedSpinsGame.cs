using System;
using System.Collections.Generic;
using System.Text;

namespace GamblersFallacy
{
    public class MultipleSpinsSimulation
    {
        public int MaxSpins { get; set; }
        public int StartAmount { get; set; }

        private MultipleSpinsResult multipleSpinsResult;
        private SingleSpinGame singleSpinGame = new SingleSpinGame();
        
        public MultipleSpinsSimulation(int maxSpins, int startAmount)
        {
            MaxSpins = maxSpins;
            StartAmount = startAmount;
        }

        private bool DoSpinLandOnRed()
        {
            // spin wheel 0 = black, 1 = red
            var result = new Random().Next(0, 2);

            return result == 1 ? true : false;

        }

        /// <summary>
        /// Automates playing the same color for a fixed amount of spins or untill bankruptcy. 
        /// </summary>
        /// <param name="maxSpins"></param>
        /// <param name="startAmount"></param>
        public MultipleSpinsResult DoMultipleSpins()
        {
            multipleSpinsResult = new MultipleSpinsResult()
            {
                Amount = StartAmount,
                StartAmount = StartAmount
            };


            for (int i = 1; i <= MaxSpins; i++)
            {
                if (multipleSpinsResult.Amount > 0)
                {
                    var isRed = singleSpinGame.PlaySingleSpin(true);
                    multipleSpinsResult.Amount += isRed ? +10 : -10;

                    if (multipleSpinsResult.Amount == 10)
                     {

                    }

                    //check for bancrupcy 
                    if (multipleSpinsResult.Amount > 0)
                    {
                        multipleSpinsResult.SpinsPlayed = i;
                        if (multipleSpinsResult.Amount > multipleSpinsResult.HighestAmount)
                        {
                            multipleSpinsResult.HighestAmount = multipleSpinsResult.Amount;

                        }
                    }
                    else
                    {
                        break;
                    }   
                }
            }
            
            return multipleSpinsResult;
        }

       

        public class MultipleSpinsResult
        {
            public int SpinsPlayed { get; set; }
            public bool Bancrupt { get; set; }
            public int Amount { get; set; }
            public int StartAmount { get; set; }
            public int HighestAmount { get; set; }

            public bool MadeProfit()
            {
                return Amount > StartAmount;
            }

            public int AmountDiff()
            {
                return Amount - StartAmount;
            }

            public void Print()
            {
                Console.Clear();

                var bankrupt = Amount < 1 ? true : false;

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"MULTIPLE SPIN SIMULATION *******************");
                if (bankrupt)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You died! after {SpinsPlayed} spins.");

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Highest amount: {HighestAmount}");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Money: 0 ");
                }
                else
                {
                    
                    if (AmountDiff() > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine($"You actually made a {AmountDiff()} profit!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine($"You end up {AmountDiff()} porer");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Spins: {SpinsPlayed}");
                    Console.WriteLine($"Highest amount: {HighestAmount}");
                    Console.WriteLine($"Money: {Amount} ");
                    
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"*********************** ANY KEY TO CONTINUE");

                Console.ReadKey();
                
            }
        }
    }
}
