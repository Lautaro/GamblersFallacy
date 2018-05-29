using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static GamblersFallacy.MultipleSpinsSimulation;

namespace GamblersFallacy
{
    public class BatchSimualtion
    {
        public MultipleSpinsSimulation Simulation { get; set; }

        public int AmountOfSimulations { get; set; }
        public int SpinsPerSimuation { get; set; }

        public BatchSimualtion(int amountOfSimulations,  MultipleSpinsSimulation simulation)
        {
            var results = new List<MultipleSpinsResult>();

            for (int i = 1; i < amountOfSimulations; i++)
            {
                var multiSpin = new MultipleSpinsSimulation(simulation.MaxSpins, simulation.StartAmount);

                results.Add(multiSpin.DoMultipleSpins());

            }

            var amountProfiting = (from r in results
                                   where r.MadeProfit() == true
                                   select r).Count();

            var amountLosses = (from r in results
                                   where !r.MadeProfit() == true
                                   select r).Count();

            var amountBankrupt = (from r in results
                                  where r.Bancrupt == true
                                  select r).Count();

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine($"You made a profit {amountProfiting} times");
            Console.WriteLine($"You took a loss {amountLosses} times");
            Console.WriteLine($"You went bankrupt {amountBankrupt} times");

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Any key to continue.....");

            Console.ReadKey();
        }


    }
}
