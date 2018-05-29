using System;
using System.Collections.Generic;
using System.Text;

namespace GamblersFallacy
{
    class SingleSpinGame
    {

        public bool PlaySingleSpin(bool betOnRed )
        {
            // place bets


            // spin wheel 0 = black, 1 = red
            var result = new Random().Next(0, 2);

            // check outcome
             return (result == 1) == (betOnRed);

            // resolve bet
            
        }

    }
}
