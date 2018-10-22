using System;
using Klassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KlassenTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteHochzeiten()
        {
            Person mario = new Person("Mario", "Schmidt", Person.Geschlechter.Männlich, new DateTime(2002, 2, 2));
            Person katrin = new Person("Katrin", "Meier", Person.Geschlechter.Weiblich, new DateTime(1980, 2, 2));
            Person andreas = new Person("Andreas", "Schulz", Person.Geschlechter.Männlich, new DateTime(1980, 2, 2));

            mario.Ehepartner = katrin;
            if (mario.Ehepartner != null)
                Assert.Fail();

            katrin.Ehepartner = andreas;
            if(katrin.Ehepartner != andreas || andreas.Ehepartner != katrin)
            {
                Assert.Fail();
            }
        }
    }
}
