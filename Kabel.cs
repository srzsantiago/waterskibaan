using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> _lijnen { get; set; }
        public Kabel()
        {
            _lijnen = new LinkedList<Lijn>();
        }

        public Boolean IsStartPositieLeeg()
        {
            if (_lijnen.Count == 0)
            {
                return true;
                
            }

            foreach (var lijnElement in _lijnen)
            {
                if (lijnElement.PositieOpDeKabel == 0)
                {
                    return false;
                }
            }

            return true;
        }

       

        public void NeemLijnInGebruik(Lijn lijn)
        {

            if(lijn.PositieOpDeKabel == 0 && IsStartPositieLeeg())
            {
                _lijnen.AddFirst(lijn);
            }

        }

        public void VerschuifLijnen()
        {

            foreach (var lijnElement in _lijnen)
            {
                if(lijnElement.PositieOpDeKabel < 9)
                    lijnElement.PositieOpDeKabel = lijnElement.PositieOpDeKabel + 1;
                else
                {
                    lijnElement.PositieOpDeKabel = 0;
                    _lijnen.Last.Value.Sporter.AantalRondenNogTeGaan -= 1;
                }
                    
            }

        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn laaste= null;

            if (_lijnen.Last.Value.PositieOpDeKabel == 9 && _lijnen.Last.Value.Sporter.AantalRondenNogTeGaan != 0)
            {
                laaste = _lijnen.Last.Value;
                _lijnen.RemoveLast();

            }
            return laaste;
        }

        public override String ToString()
        {
            String posities= "";
            foreach (var lijnElement in _lijnen)
            {
                posities = posities + lijnElement.PositieOpDeKabel + "|";
            }
            return posities;

        }

        public void TestOpdracht2()
        {
            Console.WriteLine($"Startpositie is {this.IsStartPositieLeeg()}");
            this.NeemLijnInGebruik(new Lijn(0));
            Console.WriteLine($"Startpositie is {this.IsStartPositieLeeg()}");
            this.NeemLijnInGebruik(new Lijn(0));
            Console.WriteLine(ToString());

            for (int i = 0; i < 9; i++)
            {
                VerschuifLijnen();
                this.NeemLijnInGebruik(new Lijn(0));
                Console.WriteLine(ToString());
                
            }

            VerwijderLijnVanKabel();
            Console.WriteLine(ToString());
            

        }
    }
}
