using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class SchnabeltierEi : Ei
    {
        public SchnabeltierEi():base()
        {

        }
        public SchnabeltierEi(IEiLeger mutter)
        {
            this.Mutter = mutter;
            this.Gewicht = 50;
        }
    }
}
