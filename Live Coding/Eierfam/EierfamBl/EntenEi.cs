using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class EntenEi : Ei
    {
        private EntenEi():base()
        {

        }
        public EntenEi(Gefluegel mutter) : base(mutter)
        {
            this.Gewicht = (new Random()).Next(25, 61);
        }
    }
}
