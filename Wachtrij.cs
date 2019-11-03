using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public abstract class Wachtrij
    {
        Queue<Sporter> rij = new Queue<Sporter>();
        public int MAX_LENGTE_RIJ;

        protected Wachtrij(int lengte)
        {
            MAX_LENGTE_RIJ = lengte;
        }

        public List<Sporter> GetAlleSporters()
        {
            List<Sporter> alleSporters = new List<Sporter>();
            foreach (var item in rij)
            {
                alleSporters.Add(item);
            }
            return alleSporters;
        }

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            rij.Enqueue(sporter);
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> sporterAanBeurt = new List<Sporter>();
            if (aantal > rij.Count)
            {
                int count = rij.Count;
                for (int i = 0; i < count; i++)
                {
                    sporterAanBeurt.Add(rij.Dequeue());
                }
            }
            else
            {
                for (int i = 0; i < aantal; i++)
                {
                    sporterAanBeurt.Add(rij.Dequeue());
                }
            }
            
            
            return sporterAanBeurt;

        }

        public override string ToString()
        {
            return $"\nzitten {rij.Count} personen in de rij";
        }
    }
}
