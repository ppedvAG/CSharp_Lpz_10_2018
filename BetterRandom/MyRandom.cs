using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRandom
{
    /// <summary>
    /// Ableitung der Random-Klasse,
    /// bei der die Next-Methode überschrieben wurde, um den 2. Parameter
    /// als inklusiven und nicht exklusiven Wert zu interpretieren
    /// </summary>
    public class MyRandom : Random
    {
        public int NextInclusive(int von, int bis)
        {
            return base.Next(von, bis + 1);
        }

        public override int Next(int minValue, int maxValue)
        {
            return base.Next(minValue, maxValue + 1);
        }
    }
}
