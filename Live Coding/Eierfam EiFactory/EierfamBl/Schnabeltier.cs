using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfamBl
{
    public class Schnabeltier : Saeugetier, IEiLeger //, Gefluegel
    {
        public List<Ei> Eier { get; set; }

        public double Gewicht { get; set; }

        public void EiLegen()
        {
            if (this.Gewicht>2000)
            {
                Ei ei = EiFactory.GetEi(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public void Fressen()
        {
            if (this.Gewicht<4500)
            {
                this.Gewicht += 250;
            }
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }

        public void Tauchen()
        {
            throw new System.NotImplementedException();
        }
    }
}