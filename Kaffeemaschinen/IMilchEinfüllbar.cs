using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschinen
{
    //Interface welches Objekte kennzeichnet, die ein Property "Milchstand" besitzen
    public interface IMilchEinfüllbar
    {
        int Milchstand { get; set; }
    }
}
