using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EierfamBl
{
    public abstract class Gefluegel : IEiLeger
    {
        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        private void OnEigenschaftGeaendert(string property)
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new GefluegelEventArgs(property));
            }
        }

        protected Gefluegel()
        {

        }

        public Gefluegel(string name)
        {
            this.Name = name;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnEigenschaftGeaendert("Name");
            }
        }

        private double _gewicht;

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert("Gewicht");
            }
        }

        public List<Ei> Eier { get; set; } = new List<Ei>();
        //public EiFactory EiFabrik { get; private set; } = new EiFactory();

        public abstract void Fressen();

        public abstract void EiLegen();

        // ToString von Object überschreiben
        //public override string ToString()
        //{
        //    return this.Name;
        //}


    }

    public class GefluegelEventArgs : EventArgs
    {
        public GefluegelEventArgs(string propertyName)
        {
            this.GeaenderteProperty = propertyName;

           
        }

        public string GeaenderteProperty { get; set; }
    }
}
