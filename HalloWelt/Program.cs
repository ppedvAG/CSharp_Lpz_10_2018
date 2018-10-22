using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloWelt
{
    class Program
    {
        //args = Zusatzinformationen
        static void Main(string[] args)
        {
            string name;

            Console.Write("Name: ");
            //Initialisierung
            name = Console.ReadLine();

            Console.Write($"Bitte gib ein Alter zwischen {byte.MinValue} und {byte.MaxValue} ein: ");
            byte alter = byte.Parse(Console.ReadLine());

            Console.Write("Zeilenumbruch\tTabulator\n");
            //Fügt automatisch \n ans Ende des Strings
            System.Console.WriteLine("Hallo Welt");

            //cw Tab Tab (Snippet)
            Console.WriteLine("Name der Person: " + name);
            Console.WriteLine("Name der Person: {0}", name);
            //Interpolated Strings
            Console.WriteLine($"Name der Person: {name} ({alter} Jahre)");

            //Console.Beep();
            System.Console.ReadKey();
        }
    }
}
