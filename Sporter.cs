using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Waterskibaan
{
    public class Sporter
    {
        private int aantalRondenNogTeGaan = 0;
        private int punten = 0;
        Random rand = new Random();
        int a;
        Byte[] bytes;
        

        public int AantalRondenNogTeGaan
        {
            get { return aantalRondenNogTeGaan; }
            set
            {
                aantalRondenNogTeGaan = value;
            }
        }

        public Zwemvest Zwemvest{get; set;}

        public Skies Skies{get; set;}

        public Color KledingKleur{get; set;}

        public List<IMoves> Moves{get; set;}
        public IMoves HuidigeMove
        {
            get { return Moves[rand.Next(0, Moves.Count())]; }
            set { }
        }

        public int Punten
        {
            get { return punten; } set { punten += value; }
        }
        public Sporter(List<IMoves> moves)
        {
            Moves = moves;
            bytes = new Byte[3];
            rand.NextBytes(bytes);
            KledingKleur = Color.FromRgb(bytes[0], bytes[1], bytes[2]);
            a = rand.Next();

        }

        
    }
}
