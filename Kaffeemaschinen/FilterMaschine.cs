using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschinen
{
    public class FilterMaschine : Kaffeemaschine
    {
        //Kurzversion: prop
        public int Kaffeekapazität { get; private set; }

        //Ausprogrammiertes Property: propfull
        private int _kaffeestand = 0;

        public int Kaffeestand
        {
            get { return _kaffeestand; }
            set
            {
                if (value > Kaffeekapazität)
                {
                    base.LöseBediedungsfehlerEventAus("Zu viel Kaffee!");
                    _kaffeestand = Kaffeekapazität;
                }
                else
                {
                    _kaffeestand = value;
                }
            }
        }


        public FilterMaschine(string name, int wasserkapazität, int kaffeekapazität) : base(name, wasserkapazität)
        {
            Kaffeekapazität = kaffeekapazität;
        }

        public override bool BereiteKaffeeZu(int menge)
        {
            if (Kaffeestand < menge)
            {
                base.LöseBediedungsfehlerEventAus("Zu wenig Kaffee!");
                return false;
            }

            if (!base.BereiteKaffeeZu(menge))
                return false;

            Kaffeestand -= menge;
            return true;
        }

        public override string ToString()
        {
            //base.ToString() ruft immer die Implementierung der direkten Elternklasse auf, also in diesem
            //Fall von Kaffeemaschine
            return $"{base.ToString()}\nKaffeestand {Kaffeestand}/{Kaffeekapazität}";
        }
    }
}
