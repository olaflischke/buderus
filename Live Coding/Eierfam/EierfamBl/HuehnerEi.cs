using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EierfamBl
{
    [XmlInclude(typeof(Ei))]
    public class HuehnerEi : Ei
    {
        private HuehnerEi():base()
        {

        }
        public HuehnerEi(Gefluegel mutter) : base(mutter)
        {
            Random random = new Random();
            this.Gewicht = random.Next(45, 81);
        }
    }
}
