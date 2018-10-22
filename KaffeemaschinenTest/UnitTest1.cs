using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kaffeemaschinen;

namespace KaffeemaschinenTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteWasserstand()
        {
            PadMaschine padmaschine = new PadMaschine("Pad1", 1000);

            padmaschine.Wasserstand += 500;
            Assert.AreEqual(500, padmaschine.Wasserstand);

            Vollautomat vollmaschine = new Vollautomat("Milch", 1000, 500, 500);
            vollmaschine.Milchstand += 600;
            Assert.AreEqual(vollmaschine.Milchkapazität, vollmaschine.Milchstand);


            //Polymorphie
            Kaffeemaschine kaffeemaschine = new FilterMaschine("Filter1", 1000, 1000);
            kaffeemaschine.Wasserstand += 2000;
            if (kaffeemaschine.Wasserstand > kaffeemaschine.Wasserkapazität)
                Assert.Fail();

            //Kaffeestand testen
            FilterMaschine filtermaschine = (FilterMaschine)kaffeemaschine;
            filtermaschine.Kaffeestand += 1200;
            if (filtermaschine.Kaffeestand > filtermaschine.Kaffeekapazität)
                Assert.Fail();


            Kaffeemaschine[] maschinen = new Kaffeemaschine[] { padmaschine, vollmaschine, filtermaschine };

            foreach (Kaffeemaschine maschine in maschinen)
            {
                Console.WriteLine(maschine.Wasserstand);
                //prüft auf FIltermaschine oder abgeleitete Klasse davon (Vollautomat)
                if (maschine is FilterMaschine)
                {
                    FilterMaschine fm = (FilterMaschine)maschine;
                    Console.WriteLine(fm.Kaffeestand);
                }

                //prüft nur auf Filtermaschine
                if(maschine.GetType()  == typeof(FilterMaschine))
                {

                }

            }
        }
    }
}
