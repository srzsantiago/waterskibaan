using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Spring : IMoves
    {
        Random rand = new Random();
        public int Move()
        {
            int punten = 0;
            if (rand.Next(1) == 0)
            {
                punten = 5;
                Console.WriteLine("de sporter springt en krijgt 5 punten!");
            }
            else
            {
                Console.WriteLine("de sporter faalt en valt, dus 0 punten");
            }
            return punten;
        }
    }
}
