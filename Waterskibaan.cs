using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public LijnenVoorraad lijnVoorraad { get; set; }
        public Kabel Kabel { get; set; }
        Random random = new Random();

        public Waterskibaan()
        {
            lijnVoorraad = new LijnenVoorraad();
            Kabel = new Kabel();
            lijnVoorraad.SetAantalLijnen(15);
            

        }

        public void VerplaatsKabel()
        {
            Boolean actieNodig = false;   
            
            foreach (var lijnElement in Kabel._lijnen)
            {
                if (lijnElement.PositieOpDeKabel < 9)
                    lijnElement.PositieOpDeKabel = lijnElement.PositieOpDeKabel + 1;
                else
                {
                    actieNodig = true;
                }
            }

            if (actieNodig)
            {
                Lijn lijn = Kabel.VerwijderLijnVanKabel();
                if (lijn.Sporter.AantalRondenNogTeGaan > 1)
                {
                    lijn.PositieOpDeKabel = 0;
                    Kabel._lijnen.AddFirst(lijn);
                }
                else
                {                    
                    lijnVoorraad.SetAantalLijnen(lijnVoorraad.GetAantalLijnen() + 1);
                    
                }
                
                
            }
            
        }

        public void SporterStart(Sporter sp)
        {
            if (Kabel.IsStartPositieLeeg() && sp.Skies != null && sp.Zwemvest != null)
            {
                Lijn lijn = lijnVoorraad.VerwijderEersteLijn();
                lijn.Sporter = sp;
                Kabel.NeemLijnInGebruik(lijn);
                sp.AantalRondenNogTeGaan = random.Next(1, 5);
                //Console.WriteLine("je hebt al het materiaal om te beginnen!");
            } else if(sp.Skies == null || sp.Zwemvest == null) {
                Console.WriteLine("Je hebt skies en een zwemvest nodig!");
            }
        }

        public override string ToString()
        {
            return $"{lijnVoorraad.ToString()} {Kabel.ToString()}";
        }

        public void TestOpdracht8()
        {

            List<IMoves> list = MoveCollection.GetWillekeurigeMoves();
            Sporter sporterTest = new Sporter(list);
            
            this.SporterStart(sporterTest);

            sporterTest.Skies = new Skies();
            sporterTest.Zwemvest = new Zwemvest();

            this.SporterStart(sporterTest);


        }
    }
}
