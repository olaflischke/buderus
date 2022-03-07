using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public class Huhn:Gefluegel
    {
        public Huhn(string name):base(name)
        {
            this.Gewicht = 1000;
        }

        public override void Fressen()
        {
            if (this.Gewicht<3000)
            {
                //this.Gewicht = this.Gewicht + 100;
                this.Gewicht += 100;
            }
        }

        public override void EiLegen()
        {
            if (this.Gewicht>1500)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        // Aufruf: double a = Add(12, 13); -> a = 25
        private double Add(double zahl1, double zahl2) // Public Function Add(Zahl1 As Double, Zahl2 As Double) As Double
        {
            return zahl1 + zahl2;
        }

    }
}
