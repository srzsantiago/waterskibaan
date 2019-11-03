using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij,IWachtrij
    {
        public InstructieGroep() : base(5) { }

        public override string ToString()
        {
            return $"In deze wachtrij \n(InstructieGroep) {base.ToString()}";
        }
    }
}
