using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradingDayDal
{
    /// <summary>
    /// Stellt einen Währungskurs dar.
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// 3-buchstabiges ISO-Kürzel der Währung
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Umrechnungskurs zum Euro (1 EUR = Wert)
        /// </summary>
        public double EuroRate { get; set; }
    }
}