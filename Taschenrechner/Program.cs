using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        //eigener Datentyp
        enum Rechenoperationen { Add = 1, Subtr = 2, Mult = 3, Div = 4 }

        static void Main(string[] args)
        {

            //EnumMitMehrerenWertenGleichzeitig();

            //TestDerNachgebautenWriteLineMethode();

            Console.Write("1. Zahl: ");
            double zahl1 = double.Parse(Console.ReadLine());
            Console.Write("2. Zahl: ");
            double zahl2 = double.Parse(Console.ReadLine());

            #region Alternativ mit TryParse
            //double number1;
            //while (!double.TryParse(Console.ReadLine(), out number1))
            //{
            //    Console.WriteLine("Gebe Zahl erneut ein!");
            //}
            //double number2;
            //while (!double.TryParse(Console.ReadLine(), out number2))
            //{
            //    Console.WriteLine("Gebe Zahl erneut ein!");
            //}
            #endregion

            //Rechenoperation eingeben
            Console.WriteLine("Addition: 1\nSubtraktion: 2\nMultiplikation: 3\nDivision 4");
            Console.Write("Rechenoperation: ");
            int operationAlsInt = int.Parse(Console.ReadLine());

            //Caste Integer zu Rechenoperation
            Rechenoperationen operation = (Rechenoperationen)operationAlsInt;

            double result = Berechne(zahl1, zahl2, operation);

            Console.WriteLine($"Ergebnis: {result}");

            double result2;
            if (BerechneMitOutParametern(zahl1, zahl2, operation, out result2))
            {
                Console.WriteLine($"Ergebnis: {result2}");
            }
            else
            {
                Console.WriteLine("Es ist ein Fehler aufgetreten!");
            }

            Console.ReadKey();
        }


        #region Enums mit bitweiser Veroderung/Verundung nutzen

        //Um mehrere Werte gleichzeitig abbilden zu können, müssen die Indizes der Enum-Werte Potenzen von 2 sein
        enum Wochentage { Montag = 1, Dienstag = 2, Mittwoch = 4, Donnerstag = 8, Freitag = 16, Samstag = 32, Sonntag = 64 }

        private static void EnumMitMehrerenWertenGleichzeitig()
        {
            //Der Termin findet nur Montags und Dienstags statt
            Wochentage ereignis = Wochentage.Montag | Wochentage.Mittwoch; //Montag und Mittwoch (bitweise-Veroderung)

            if(ereignis == Wochentage.Montag) //ist der Termin nur am Montag?? 
                Console.WriteLine("Bedingung 1 ist wahr!");

            if(ereignis == (Wochentage.Montag | Wochentage.Mittwoch)) //ist der Termin nur am Montag und Mittwoch? (bitweise veroderung)
                Console.WriteLine("Bedingung 2 ist wahr!");

            if((ereignis & Wochentage.Montag) != 0) //ist der Termin auch am Montag? (bitweise Verundung)
                Console.WriteLine("Bedingung 3 ist wahr!");

            if((ereignis & Wochentage.Montag) != 0 && (ereignis  & Wochentage.Mittwoch) != 0) //ist der Termin Montags und Mittwochs? (und evtl. auch an anderen Tagen?)
                Console.WriteLine("Bedingung 4 ist wahr!");

            if ((ereignis & Wochentage.Dienstag) != 0) //findet der Termin auch Dienstags statt?
                Console.WriteLine("Bedingung 5 ist wahr!");

            if((ereignis & Wochentage.Montag) != 0 || ereignis == (Wochentage.Dienstag | Wochentage.Mittwoch)) //Findet der Termin auch Montags oder nur Dienstags und Mittwochs statt?
                Console.WriteLine("Bedingung 6 ist wahr!");

        }
        #endregion

        private static void TestDerNachgebautenWriteLineMethode()
        {
            SchreibeInKonsole("Mein Name ist {0}", new string[] { "Alex" });
            SchreibeInKonsole("Mein Name ist {0} und ich bin {1} Jahre alt", "Anja", 32);
            Console.WriteLine("Mein Name ist {0} und ich bin {1} Jahre alt", "Markus", 28);
        }

        static double Berechne(double z1, double z2, Rechenoperationen operation)
        {
            //Unbedingt switch als Snippet benutzen bei Enumerationen!
            switch (operation)
            {
                case Rechenoperationen.Add:
                    return z1 + z2;
                case Rechenoperationen.Subtr:
                    return z1 - z2;
                case Rechenoperationen.Mult:
                    return z1 * z2;
                case Rechenoperationen.Div:
                    //Division durch 0 ergibt bei Gleitkommazahlen Unendlich (8)
                    if (z2 == 0)
                    {
                        throw new Exception("Division durch Null ist nicht erlaubt!");
                    }
                    return z1 / z2;
                default:
                    throw new Exception("Ungültige Operation");
            }
        }


        static bool BerechneMitOutParametern(double z1, double z2, Rechenoperationen operation, out double result)
        {
            result = 0;

            //Unbedingt switch als Snippet benutzen bei Enumerationen!
            switch (operation)
            {
                case Rechenoperationen.Add:
                    result = z1 + z2;
                    return true;
                case Rechenoperationen.Subtr:
                    result = z1 - z2;
                    return true;
                case Rechenoperationen.Mult:
                    result = z1 * z2;
                    return true;
                case Rechenoperationen.Div:
                    //Division durch 0 ergibt bei Gleitkommazahlen Unendlich (8)
                    if (z2 == 0)
                    {
                        return false;
                    }
                    result = z1 / z2;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Nachbau der Console.WriteLine-Methode
        /// </summary>
        static void SchreibeInKonsole(string ausgabe, params object[] werte)
        {
            //blabla{0}....{1},  "haus", "wort"
            for (int i = 0; i < werte.Length; i++)
            {
                //{{ entspricht einem {-Zeichen
                ausgabe = ausgabe.Replace($"{{{i}}}", werte[i].ToString());
            }
            Console.WriteLine(ausgabe);
        }
    }
}