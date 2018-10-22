using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Klassen
{
    class Program
    {
        static void Main(string[] args)
        {
            TestePersonen();
            AutoTests();

           
            Console.ReadKey();
        }

        private static void AutoTests()
        {
            Console.WriteLine("--Auto Tests--");

            Auto auto1 = new Auto("Audi", Auto.Antriebsarten.Benzin);
            //Strg + Leertaste
            auto1.Betriebsbereit = true;
            auto1.Farbe = Color.Chocolate;

            auto1.Farbe = Color.Coral;

            //Jede Klasse ist ein Referenztyp
            Auto auto1Copy = auto1;

            auto1Copy.Farbe = Color.Cyan;
            Console.WriteLine(auto1.Farbe);
            Console.WriteLine(auto1.ToString());

            Console.WriteLine(auto1.GetHersteller());

            //Übung: Eine echt Kopie von Auto1 anlegen
            Auto auto1EchteKopie = new Auto(auto1.GetHersteller(), auto1.GetAntriebsart());
            auto1EchteKopie.Farbe = auto1.Farbe;
            auto1EchteKopie.Betriebsbereit = auto1.Betriebsbereit;

            Auto auto1ZweiteKopie = (Auto)auto1.Clone();

        }

        static void TestePersonen()
        {
            Console.WriteLine("--Personen Tests--");

            //Varianten wie man mit DateTime.Parse ein Datumsobjekt erstellen kann:
            //https://www.dotnetperls.com/datetime-parse
            Person martin = new Person("Martin", "Tischler", Person.Geschlechter.Männlich, new DateTime(1984,10,24));
            Person anja = new Person("Violeta", "Tankova", Person.Geschlechter.Weiblich, DateTime.Parse("10/11/1985"));

            Console.WriteLine(martin.Geburtsdatum.ToShortDateString());
            #region Datime mit DateTime.Parse erzeugen
            //DateTime date = DateTime.Parse("22/02/1986");
            //Console.WriteLine(date);
            #endregion

            Console.WriteLine($"Alter: {martin.Alter}");

            Console.WriteLine(martin.Nachname);
            martin.Größe = 170;

            bool hatPartner = anja.Ehepartner != null;
            //? prüft ob das Objekt null ist oder nicht
            Console.WriteLine($"Ehepartner von Anja ist: {anja.Ehepartner?.Vorname}");

            //Hochzeit
            martin.Ehepartner = anja;
            Console.WriteLine($"Ehepartner von {martin.Name} ist {martin.Ehepartner.Name}");
            Console.WriteLine($"Ehepartner von {anja.Name} ist {anja.Ehepartner.Name}");

        }
    }
}
