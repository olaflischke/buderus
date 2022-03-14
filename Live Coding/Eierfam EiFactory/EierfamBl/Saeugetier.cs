using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfamBl
{
    public abstract class Saeugetier
    {
        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public abstract void Saeugen();
    }
}