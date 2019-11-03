using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class OpEenBeen : IMoves
    {
        Random rand = new Random();
        public int Move()
        {
            int punten = 0;
            if (rand.Next(2) == 0)
            {
                punten = 15;
                Console.WriteLine("de sporter staat op een been! WOW! 15 punten");
            }
            else
            {
                
                Console.WriteLine("de sporter faalt en valt, dus 0 punten");
            }
            return punten;
        }
    }
}
