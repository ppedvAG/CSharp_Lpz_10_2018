using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschinen
{
    public abstract class Kaffeemaschine
    {

        //Delegate-Datentypen
        public delegate void FehlerEventHandler(object sender, FehlerEventArgs args);

        //Event
        public event FehlerEventHandler Bedienungsfehler;


        public string Name { get; private set; }

        //Kurzschreibweise eines Properties, Snippet: prop
        public int Wasserkapazität { get; private set; }

        //Ausprogrammiertes Property, Snippet: propfull
        private int _wasserstand = 0;

        public int Wasserstand
        {
            get { return _wasserstand; }
            set
            {
                if(value > Wasserkapazität)
                {
                    Bedienungsfehler?.Invoke(this, new FehlerEventArgs("Wasser läuft über!"));
                    _wasserstand = Wasserkapazität;
                }
                else
                {
                    _wasserstand = value;
                }
            }
        }

      
        public Kaffeemaschine(string name, int wasserkapazität)
        {
            Name = name;
            Wasserkapazität = wasserkapazität;
        }


        //Methoden
        //virtuelle Methoden können in abgeleiteten Klassen überschrieben (override) werden
        public virtual bool BereiteKaffeeZu(int menge)
        {
            if (Wasserstand < menge)
            {
                Bedienungsfehler?.Invoke(this, new FehlerEventArgs("Wassermenge reicht nicht!"));
                return false;
            }

            Wasserstand -= menge;
            return true;
        }

        #region Überflüssige Hilfsmethode
        
        public void FügeWasserHinzu(int menge)
        {
            Wasserstand += menge;
        }
        #endregion

        //überschreibt die ToString-Implementierung der Klasse Object
        public override string ToString()
        {   
            return $"{Name}\nWasserstand: {Wasserstand}/{Wasserkapazität} ml";
        }

        //protected: nur von abgeleiteten Klassen aus aufrufbar
        protected void LöseBediedungsfehlerEventAus(string meldung)
        {
            Bedienungsfehler?.Invoke(this, new FehlerEventArgs(meldung));
        }
    }
}
