using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahlenraten
{
    class Program
    {
        static Random randomReferenz;

        static void Main(string[] args)
        {
            //Strg+Leertaste: Button rechts unten: Übersicht aller Snippets

            //Samen wird beim Random-Konstruktor gesäht, d.h. die akutelle Systemzeit wird ausgelesen
            //new Random nur 1 Mal im gesamten Program aufrufen
            Random random = new Random();

            randomReferenz = random;

            //Zufallszahl zwischen 1 und 10
            byte zufallszahl = (byte)random.Next(1, 11);
            byte gerateneZahl = 0;
            int versuche = 0;


            //Strg + K + D(Edit->Advanced->Format Document): Dokument reformatieren

            #region Variante mit kopfgesteuerter While-Schleife
            //while (gerateneZahl != zufallszahl)
            //{
            //    Console.Write("Bitte rate die Zahl zwischen 1 und 10: ");
            //    gerateneZahl = byte.Parse(Console.ReadLine());
            //    //versuche = versuche + 1;
            //    versuche++;

            //    if (zufallszahl < gerateneZahl)
            //    {
            //        Console.WriteLine("Zahl war zu groß");
            //    }
            //    else if(zufallszahl > gerateneZahl)
            //    {
            //        Console.WriteLine("Zahl war zu klein");
            //    }
            //}
            #endregion

            //Variante mit Do-While
            do
            {
                Console.Write("Bitte rate die Zahl zwischen 1 und 10: ");
                gerateneZahl = byte.Parse(Console.ReadLine());
                //versuche = versuche + 1;
                versuche++;

                if (zufallszahl < gerateneZahl)
                {
                    Console.WriteLine("Zahl war zu groß");
                }
                else if (zufallszahl > gerateneZahl)
                {
                    Console.WriteLine("Zahl war zu klein");
                }

            } while (gerateneZahl != zufallszahl);

            //Jetzt wurde die Zahl richtig geraten
            Console.WriteLine($"Zahl wurde nach {versuche} Versuchen geraten!");
            //Wieviele Versuche hat der Nutzer gebraucht

            //forciert einen Durchlauf der Garbage-Collection
            //GC.Collect();

            Console.ReadKey();
        }
    }
}
