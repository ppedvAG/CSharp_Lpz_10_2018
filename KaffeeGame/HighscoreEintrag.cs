using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeeGame
{
    /// <summary>
    /// Bildet einene HighscoreEintrag ab
    /// </summary>
    public class HighscoreEintrag
    {
        public int Score { get; private set; }
        public string Name { get; private set; }
        public DateTime Datum { get; private set; }

        public HighscoreEintrag(int score, string name, DateTime datum)
        {
            Score = score;
            Name = name;
            Datum = datum;
        }

        public override string ToString()
        {
            return $"{Name} \t{Score}\t {Datum.ToShortDateString()}";
        }
    }
}
