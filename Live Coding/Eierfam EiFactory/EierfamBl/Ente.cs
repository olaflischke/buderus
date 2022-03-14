using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class Ente : Gefluegel
    {
        private Ente():base()
        {

        }

        public Ente(string name) : base(name)
        {
            this.Gewicht = 750;
        }

        public override void EiLegen()
        {
            if (this.Gewicht>1500)
            {
                Ei ei = EiFactory.GetEi(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 2000)
            {
                this.Gewicht += 100;
            }
        }
    }
}
