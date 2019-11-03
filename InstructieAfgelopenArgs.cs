using System.Collections.Generic;

namespace Waterskibaan
{
    public class InstructieAfgelopenArgs
    {
        public List<Sporter> Sporters { get; set; }

        public InstructieAfgelopenArgs(List<Sporter> Sporters)
        {
            this.Sporters = Sporters; 
        }
    }
}