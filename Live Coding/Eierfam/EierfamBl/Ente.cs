using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class Ente : Gefluegel
    {
        public Ente():base("Neue Ente")
        {
            this.Gewicht = 2000;
        }

        public override void EiLegen()
        {
            if (this.Gewicht>1000)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 2500)
            {
                this.Gewicht += 100;
            }
        }

        public int Steuerkurs { get; set; }
    }
}
