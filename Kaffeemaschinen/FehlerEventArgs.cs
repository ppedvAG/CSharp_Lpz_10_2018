using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschinen
{
    public class FehlerEventArgs : EventArgs
    {
        public string Fehlermeldung { get; set; }

        public FehlerEventArgs(string fehlermeldung)
        {
            Fehlermeldung = fehlermeldung;
        }
    }
}
