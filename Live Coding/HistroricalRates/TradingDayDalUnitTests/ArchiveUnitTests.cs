using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TradingDayDal;

namespace TradingDayDalUnitTests
{
    [TestClass]
    public class ArchiveUnitTests
    {
        string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";

        [TestMethod]
        public void IsArchiveInitializing()
        {
            Archive archive = new Archive(url);

            Rate usd = archive.TradingDays.FirstOrDefault()?.Rates?.FirstOrDefault();
            if (usd!=null)
            {
                Console.WriteLine($"USD: {usd.EuroRate}");
            }

            Assert.AreEqual(GetCubeTimeCount(url), archive.TradingDays.Count);
        }

        private int GetCubeTimeCount(string url)
        {
            // TODO: Ersetzen durch vernünftige Analyse
            return 64;
        }
    }
}
