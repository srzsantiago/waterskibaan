using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("============Opdracht 2 test==============");
            //Kabel kabelTest = new Kabel();
            //kabelTest.TestOpdracht2();

            //Console.WriteLine("============Opdracht 3 test==============");
            //LijnenVoorraad testkabel = new LijnenVoorraad();
            //testkabel.TestOpdracht3();

            //Console.WriteLine("===========================Test lijst met move en score=====================");
            //List<IMoves> list = new List<IMoves>();
            //list = MoveCollection.GetWillekeurigeMoves();
            //Sporter santi = new Sporter(list);

            //foreach (var item in santi.Moves)
            //{
            //    santi.Punten = item.Move();

            //}
            //Console.WriteLine($"Total punten {santi.Punten}");

            //Console.WriteLine("=================Opdracht 8 test=======================");
            //Waterskibaan waterSkiTest = new Waterskibaan();
            //waterSkiTest.TestOpdracht8();
            //Console.ReadLine();

            Game game = new Game();
            game.Initialize();
        }
    }
}
