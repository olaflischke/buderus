using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TradingDayDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            this.Date = Convert.ToDateTime(tradingDayNode.Attribute("time").Value);

            //CultureInfo ciEzb = new CultureInfo("en-US");
            //NumberFormatInfo nfiEzb = ciEzb.NumberFormat;

            NumberFormatInfo nfiEzb = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            // Methoden-/Lambda-Syntax
            var q = tradingDayNode.Elements().Where(el => el.Attributes().Any(at => at.Name == "rate" || at.Name == "currency"))
                                            .Select(el => new Rate()
                                            {
                                                Symbol = el.Attribute("currency").Value,
                                                EuroRate = Convert.ToDouble(el.Attribute("rate").Value, nfiEzb)
                                            });

            this.Rates = q.ToList();
        }

        /// <summary>
        /// Das Datum des Handelstages.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Die Währungen, die an diesem Tag gehandelt wurden.
        /// </summary>
        public List<Rate> Rates { get; set; }
    }
}