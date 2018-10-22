using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschinen
{
    public class MilchPadMaschine : PadMaschine, IMilchEinfüllbar
    {
        //Kurzversion: prop
        public int Milchkapazität { get; private set; }

        //Ausprogrammiertes Property: propfull
        private int _milchstand = 0;

        public MilchPadMaschine(string name, int wasserkapazität, int milchkapazität) : base(name, wasserkapazität)
        {
            Milchkapazität = milchkapazität;
        }

        public int Milchstand
        {
            get { return _milchstand; }
            set
            {
                if (value > Milchkapazität)
                {
                    base.LöseBediedungsfehlerEventAus("Zu viel Milch!");
                    _milchstand = Milchkapazität;
                }
                else
                {
                    _milchstand = value;
                }
            }
        }

        public override bool BereiteKaffeeZu(int menge)
        {
            if (Milchstand < menge)
            {
                base.LöseBediedungsfehlerEventAus("Zu wenig Milch!");
                return false;
            }

            if (!base.BereiteKaffeeZu(menge))
                return false;

            Milchstand -= menge;
            return true;
        }
    }
}
