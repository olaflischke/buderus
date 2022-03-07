using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfamBl
{
    public abstract class Gefluegel
    {
        public Gefluegel(string name)
        {
            this.Name = name;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Gewicht { get; set; }
        public List<Ei> Eier { get; set; } = new List<Ei>();

        public abstract void Fressen();

        public abstract void EiLegen();

        // ToString von Object überschreiben
        public override string ToString()
        {
            return this.Name;
        }


    }
}
