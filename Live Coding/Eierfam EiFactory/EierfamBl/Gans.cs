using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class Gans : Gefluegel
    {
        public Gans():base("Neue Gans")
        {
            this.Gewicht = 2000;
        }

        public override void EiLegen()
        {
            if (this.Gewicht>2000)
            {
                Ei ei = EiFactory.GetEi(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 5000)
            {
                this.Gewicht += 250;
            }
        }

        public int Steuerkurs { get; set; }
    }
}
