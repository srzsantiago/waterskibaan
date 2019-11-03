using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>();
        
        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
            Lijn eersteLijn = null;
            if (_lijnen.Count > 0)
            {
                eersteLijn = _lijnen.Peek();
                _lijnen.Dequeue();

            }
            return eersteLijn;

        }

        public int GetAantalLijnen()
        {
            return _lijnen.Count;
        }

        public void SetAantalLijnen(int aantal)
        {
            _lijnen.Clear();
            for (int i = 0; i < aantal; i++)
            {
                LijnToevoegenAanRij(new Lijn());
            }
        }

        public Queue<Lijn> GetLijnenVoorraad()
        {
            return _lijnen;
        }


        public override string ToString()
        {
            return $"{GetAantalLijnen()} lijnen op voorraad";
        }

        

        public void TestOpdracht3()
        {
            Console.WriteLine(this.ToString());
            LijnToevoegenAanRij(new Lijn());
            Console.WriteLine(this.ToString());

            for (int i = 0; i < 9; i++)
            {
                _lijnen.Enqueue(new Lijn());
            }
            

            
        }
    }
}
