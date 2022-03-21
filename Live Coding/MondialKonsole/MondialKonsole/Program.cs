using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MondialKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load(@"C:\tmp\Buderus\CS Grundlagen\Live Coding\MondialKonsole\MondialKonsole\Data\mondial.xml");

            var qPopulation = document.Root.Descendants().Where(co => co.Name.LocalName == "country")
                                                        .Select(co => new
                                                        // Projektion
                                                        {
                                                            Name = co.Elements("name").First().Value,
                                                            Population = Convert.ToInt32(co.Elements("population").Last().Value)
                                                        })
                                                        .OrderByDescending(land => land.Population)
                                                        .Take(10);

            foreach (var item in qPopulation)
            {
                Console.WriteLine($"{item.Name}: {item.Population:#,##0}");
            }

            Console.WriteLine();

            // Nullables in C#
            int a = 12;
            System.Nullable<int> b = null; // Nullable int
            int? c = null;

            a = b.HasValue ? b.Value : -99; // =WENN(Prüfung;Dann;Sonst)
            a = b ?? -99;



            var qCapitalsWithB = document.Root.Descendants("country")
                                    .Select(co => new
                                    {
                                        Name = co.Elements("name").First().Value,
                                        Capital = co.Descendants("city")
                                                    .Where(cty => cty.Attribute("id").Value == co.Attribute("capital")?.Value)
                                                    .FirstOrDefault()?
                                                    .Elements("name").First().Value ?? ""
                                    })
                                    .Where(cp => cp.Capital.StartsWith("B"));

            foreach (var item in qCapitalsWithB)
            {
                Console.WriteLine($"{item.Name}: {item.Capital}");
            }

            Console.ReadKey();
        }


    }

    //public  class CountryDesc
    //{
    //    public int Population { get; set; }
    //    public string Name { get; set; }
    //}
}
