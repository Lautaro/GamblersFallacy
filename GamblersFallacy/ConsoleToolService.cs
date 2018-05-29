using System;
using System.Collections.Generic;
using System.Text;

namespace GamblersFallacy
{
    static class InputService
    {

        public static int AcceptInputRange(int maxOption)
        {
            int result = 0;
            while (result < 1 || result > maxOption)
            {
                Console.WriteLine("Choose betwen 1 - " + maxOption);
                var input = Console.ReadKey();

                Int32.TryParse(input.KeyChar.ToString(), out result);
            }

            return result;
        }

        public static int AcceptNumericInput(int lowestInt, int highestInt)
        {
            int result;
          
                Console.WriteLine($"Input nr betwen {lowestInt} and {highestInt} ");
                var input = Console.ReadLine();

                Int32.TryParse(input, out result);

            if (result >= lowestInt && result <= highestInt)
            {
                return result;
            }
            else
            {
                return lowestInt - 1;
            }
        }
    }
}
