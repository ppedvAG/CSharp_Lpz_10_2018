using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        const int Anzahl_Zahlen = 6;
        const int Maximal_Wert = 49;

        static Random random = new Random();

        static void Main(string[] args)
        {
            int[] gerateneZahlen = new int[Anzahl_Zahlen];
            int[] gezogeneZahlen = new int[Anzahl_Zahlen];

            //Einlesen
            for (int i = 0; i < gerateneZahlen.Length; i++)
            {
                Console.Write($"{i + 1}. Zahl: ");
                gerateneZahlen[i] = int.Parse(Console.ReadLine());
            }

            //Ziehung
            for (int i = 0; i < gezogeneZahlen.Length; i++)
            {
                int potentielleNeueZahl;
                do
                {
                    potentielleNeueZahl = random.Next(1, Maximal_Wert + 1);
                } while (gezogeneZahlen.Contains(potentielleNeueZahl));

                gezogeneZahlen[i] = potentielleNeueZahl;
               
            }

            //for (int i = 0; i < gezogeneZahlen.Length; i++)
            //{
            //    int potentielleNeueZahl = random.Next(1, Maximal_Wert + 1);
            //    if (gezogeneZahlen.Contains(potentielleNeueZahl))
            //    {
            //        i--;
            //        continue;
            //    }

            //    gezogeneZahlen[i] = potentielleNeueZahl;
            //    Console.Write($"{i + 1}. gezogene Zahl: {gezogeneZahlen[i]}");
            //}


            //zeige gezogene Zahlen:
            Console.Write("Folgende Zahlen wurden gezogen: ");
            foreach (var zahl in gezogeneZahlen)
            {
                Console.Write($"{zahl},");
            }


            //Auswertung
            int treffer = 0;
            //ger.: 1, 4, 4, 5, 6, 10
            //20,4,5,18,30
            for (int i = 0; i < gezogeneZahlen.Length; i++)
            {
                if (gerateneZahlen.Contains(gezogeneZahlen[i]))
                {
                    treffer++;
                }
            }

            Console.WriteLine($"\nDu hast {treffer} richtige Zahlen!");

            #region Echt Kopie eines Arrays erstellen

            //mehrdimensional
            int[,] zweidimensional = new int[4, 2];

            //Initialisierung des Arrays mit sofortiger Zuweisung
            string[] namen = new string[] { "Hans", "Martin", "Markus" };

            //Echte Kopie eines Arras erstellen
            int[] kopieDerGerateneZahlen = new int[gerateneZahlen.Length];
            for (int j = 0; j < gerateneZahlen.Length; j++)
            {
                kopieDerGerateneZahlen[j] = gerateneZahlen[j];
            }
            //Mit Hilfsmethode
            Array.Copy(gerateneZahlen, gezogeneZahlen, gerateneZahlen.Length);
            #endregion

            Console.ReadKey();
            
        }
    }
}
