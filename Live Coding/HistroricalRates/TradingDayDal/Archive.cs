using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TradingDayDal
{
    public class Archive
    {
        /// <summary>
        /// Konstruktor für ein Archiv.
        /// </summary>
        /// <param name="url">Die URL einer GESMES-XML-Datei.</param>
        public Archive(string url)
        {
            this.TradingDays = GetData(url);
        }

        /// <summary>
        /// Liest die Daten aus der gg. GEMSE_XML-Datei und gibt eine Liste von Handelstag-Objekten zurück.
        /// </summary>
        /// <param name="url">Die URL einer GESMES-XML-Datei.</param>
        /// <returns>Eine Liste von Handelstag-Objekten.</returns>
        private List<TradingDay> GetData(string url)
        {
            List<TradingDay> days = new List<TradingDay>();

            XDocument document = XDocument.Load(url);

            var q = from xe in document.Root.Descendants()
                    where xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time")
                    // Projektion der Ergebnismenge auf TradingDays
                    select new TradingDay(xe); //{ Date = Convert.ToDateTime(xe.Attribute("time").Value) };

            days = q.ToList(); // Durch Zugriff auf die Ergebnismenge wird IEnumerable ausgeführt.

            //foreach (XElement item in q)
            //{
            //    TradingDay day = new TradingDay() { Date = Convert.ToDateTime(item.Attribute("time").Value) };
            //    days.Add(day);
            //}

            return days;
        }

        private bool CheckAttributeExistsByName(XAttribute attribute, string name)
        {
            if (attribute.Name == name)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Die Handelstage, die dieses Archiv verwaltet.
        /// </summary>
        public List<TradingDay> TradingDays { get; set; }
    }
}