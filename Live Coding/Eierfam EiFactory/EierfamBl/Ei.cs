using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EierfamBl
{
    //[XmlInclude(typeof(HuehnerEi)), XmlInclude(typeof(GaenseEi))]
    public abstract class Ei
    {
        protected Ei()
        {

        }

        // Konstuktor für ein Ei
        // Ei ei = new Ei();
        public Ei(IEiLeger mutter)
        {
            // Zufällig erzeugte Farbe & Gewicht

            // Zufallsgenerator
            Random random = new Random();
            //this.Gewicht = random.Next(45, 81);
            //_gewicht = random.Next(45, 81);
            this.Farbe = (Eifarbe)random.Next(Enum.GetNames(typeof(Eifarbe)).Length); // DirectCast - liefert eine Exception, wenn Cast fehlschlägt.

            this.Mutter = mutter;

        }

        // "Auto-Property"
        // Property mit automatisch (durch den Compiler) generiertem Backing Field
        public Guid Id { get;  set; } = Guid.NewGuid(); // Auto-Property-Initializer (Initiale Wertzuweisung zur Auto-Property)

        //// Backing Field
        //private Guid _id;

        //// Öffentliche Property
        //public Guid Id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        // Backing Field
        private double _gewicht; // Private mGewicht as Double

        // Öffentliche Property
        public double Gewicht
        {
            get // eiGewicht = ei.Gewicht;
            {
                return _gewicht;
            }
             set // ei.Gewicht = 50;
            {
                if (value > 0)
                {
                    _gewicht = value;
                }
            }
        }

        public DateTime Legedatum { get; set; } = DateTime.Now; // DateTime.Today; 

        public Eifarbe Farbe { get; set; }

        [XmlIgnore]
        public IEiLeger Mutter { get; set; }
    }


    public enum Eifarbe
    {
        Hell,
        Dúnkel,
        Gruen
    }

}
