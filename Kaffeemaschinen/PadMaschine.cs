using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschinen
{
    public class PadMaschine : Kaffeemaschine
    {
        //Properties
        public bool PadEingelegt { get; set; } = false;

        //Konstruktor
        public PadMaschine(string name, int wasserkapazität) : base(name, wasserkapazität)
        {
            
        }

        //Weitere Methoden
        public override bool BereiteKaffeeZu(int menge)
        {
            if (!PadEingelegt)
            {
                base.LöseBediedungsfehlerEventAus("Kein Pad eingelegt!");
                return false;
            }

            if (!base.BereiteKaffeeZu(menge))
                return false;

            PadEingelegt = false;
            return true;
        }

        public override string ToString()
        {
            return $"{base.ToString()} \nPad eingelegt: " + (PadEingelegt ? "Ja" : "Nein");
        }
    }
}
