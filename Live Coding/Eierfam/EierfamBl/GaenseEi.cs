using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EierfamBl
{
    [XmlInclude(typeof(Ei))]
    public class GaenseEi : Ei
    {
        private GaenseEi():base()
        {

        }
        public GaenseEi(Gefluegel mutter) : base(mutter)
        {
            this.Gewicht = (new Random()).Next(60, 121);
        }
    }
}
