using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij, IWachtrij 
    {
        public WachtrijInstructie() : base(100) { }

        public override string ToString()
        {
            return $"In deze wachtrij (WachtrijInstructie) {base.ToString()}";
        }
    }
}
