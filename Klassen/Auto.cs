using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    //Diese Klasse ist ohne Properties definiert und zeigt damit den Ansatz von Java oder C++
    //In modernen C#-Anwendungen sollen keine öffentlichen Klassenvariablen mehr benutzt werden
    //sondern Properties, siehe Person-Klasse
    public class Auto : ICloneable
    {
        public static int AnzahlAutos = 0;


        public enum Antriebsarten { Elektro, Diesel, Benzin }

        //F12: Zur Definition des Datentypens springen
        public Color Farbe = Color.Aqua;
        public bool Betriebsbereit = false;
        private string hersteller;
        private Antriebsarten antriebsart;
        private int Benzinstand;

        //Konstruktor: Heißt genauso wie Klasse, kein Rückgabewert
        public Auto(string hersteller, Antriebsarten antriebsart)
        {
            this.hersteller = hersteller;
            this.antriebsart = antriebsart;
            Auto.AnzahlAutos++;
        }

        //Standardkonstruktor
        //public Auto()
        //{

        //}

        //Methoden
        public string ToString()
        {
            #region Langschreibweise
            //string betriebsbereit;
            //if(Betriebsbereit)
            //{
            //    betriebsbereit = "betriebsbereit";
            //}
            //else
            //{
            //    betriebsbereit = "nicht betriebsbereit";
            //}
            #endregion


            //Kurzschreibweise
            string betriebsbereitAlsString = (Betriebsbereit == true) ? "betriebsbereit"  : "nicht betriebsbereit";
            

            return $"{hersteller} mit Antriebart {antriebsart} und Farbe {Farbe} ist {betriebsbereitAlsString}";
        }

        public string GetHersteller()
        {
            return hersteller;
        }

        public Antriebsarten GetAntriebsart()
        {
            return antriebsart;
        }

        public int GetBenzinstand()
        {
            return Benzinstand;
        }
        
        public void SetBinzinstand(int neuerStand)
        {
            if (neuerStand < 0)
                throw new Exception("Ungültiger Benzinstand!");
            Benzinstand = neuerStand;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}