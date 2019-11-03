using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    static class MoveCollection
    {
        
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();

            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IMoves))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IMoves;

            foreach (var instance in instances)
            {
                moves.Add(instance);     
            }

            return moves;
        }
    }
}
