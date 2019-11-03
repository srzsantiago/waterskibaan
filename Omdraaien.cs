using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Omdraaien : IMoves
    {
        Random rand = new Random();
        public int Move()
        {
            int punten = 0;
            if (rand.Next(2) == 0)
            {
                punten = 10;
                Console.WriteLine("de sporter draait zich om en krijgt 10 punten!");
            }
            else
            {
                Console.WriteLine("de sporter faalt in het omdraaien, dus 0 punten");
            }
            return punten;
        }
    }
}
