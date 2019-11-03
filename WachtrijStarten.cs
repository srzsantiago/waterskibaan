using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijStarten : Wachtrij,IWachtrij
    {
        public WachtrijStarten() : base(20) { }

        public override string ToString()
        {
            return $"In deze wachtrij (WachtrijStarten) {base.ToString()}";
        }
    }
}
