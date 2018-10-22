using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    public class Person
    {

        //Properties und Felder

        public enum Geschlechter { Männlich, Weiblich, Sonstiges }
        
        //private set = Schreibender Zugriff nicht von außen möglich
        public string Vorname { get; private set; }
        public string Nachname { get; private set; }


        public static int DurchschnittlicheLebensdauer = 80;


        //Property Name:
        //public string Name { get; private set; }
        public string Name
        {
            get
            {
                return $"{Vorname} {Nachname}";
            }
        }

        //Snippet: prop
        public Geschlechter Geschlecht { get; private set; }

        //Ausführliche Property
        public int Alter
        {
            get
            {
                int jahresDifferenz = DateTime.Today.Year - Geburtsdatum.Year;
                DateTime heute = DateTime.Today;
                //hatte die Person dieses Jahr noch nicht Geburtstag?
                if (heute.Month < Geburtsdatum.Month || (heute.Month == Geburtsdatum.Month && heute.Day < Geburtsdatum.Day))
                {
                    jahresDifferenz--;
                }


                return jahresDifferenz;
            }
        }
        public DateTime Geburtsdatum { get; private set; }
        /// <summary>
        /// Größe in cm
        /// </summary>
        public int Größe { get; set; }

        //null = keine Adresse
        private Person _ehepartner = null;
        public Person Ehepartner
        {
            get
            {
                return _ehepartner;
            }
            set
            {
                //Volljährigkeit
                if (Alter < 18 || value.Alter < 18)
                {
                    Console.WriteLine("Personen müssen volljährig sein");
                    return;
                }
                //Vergleiche die Speicheradressen der beiden Objekte
                if(value == this)
                {
                    Console.WriteLine("Selbst-Heirat verboten!");
                    return;
                }
                //Sind beide unverheiratet (Polygamie-Verbot)
                if(Ehepartner != null || value.Ehepartner != null)
                {
                    Console.WriteLine("Polygamie verboten!");
                    return;
                }

                _ehepartner = value;
                value._ehepartner = this;
            }
        }

        //Konstruktor(en)

        public Person(string vorname, string nachname, Geschlechter geschlecht, DateTime geburtsdatum)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geschlecht = geschlecht;
            Geburtsdatum = geburtsdatum;
            //Name = $"{Vorname} {Nachname}";
        }

        ////Methoden
        //public bool Heirate(Person ehepartner, int übernimmNameVon)
        //{
        //    //TODO...
        //}
    }
}
