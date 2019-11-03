using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Lijn
    {
        Sporter sp;

        public Sporter Sporter { get { return sp; } set { sp = value; } }
        public int PositieOpDeKabel { get; set; }
        public int Id { get; set; }
        public static List<int> AlIDs = new List<int>();
        Random rand = new Random();

        public Lijn()
        {
            do
            {
                Id = rand.Next(1000,9000);
            } while (AlIDs.Contains(Id));
            AlIDs.Add(Id);
        }
        public Lijn(int a)//this constructor is only used for tests
        {
            PositieOpDeKabel = a;
            Sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
        }

    }
}
