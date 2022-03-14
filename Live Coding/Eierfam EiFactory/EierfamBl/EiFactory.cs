using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace EierfamBl
{
    public static class EiFactory
    {
        public static Ei GetEi(IEiLeger tier)
        {
            switch (tier)
            {
                case Huhn huhn:
                    return new HuehnerEi(huhn);
                case Gans gans:
                    return new GaenseEi(gans);
                case Ente ente:
                    return new EntenEi(ente);
                case Schnabeltier schnabeltier:
                    return new SchnabeltierEi(schnabeltier);
                default:
                    return null;
            }

            //if (tier is Huhn huhn1)
            //{
            //    return new HuehnerEi(huhn1);
            //}
            //else if (tier is Gans gans)
            //{
            //    return new GaenseEi(gans);
            //}
            //else if (tier is Ente ente1)
            //{
            //    return new EntenEi(ente1);
            //}
            //else
            //{
            //    return null;
            //}
        }
    }
}
