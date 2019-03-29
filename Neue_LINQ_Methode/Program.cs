using Neue_LINQ_Methode.Erweiterung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neue_LINQ_Methode
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 31;
            Console.WriteLine($"Quersumme: {zahl.Quersumme()}");
            Console.WriteLine("EinWort".Verdoppeln("..."));

            string[] wörter = new string[] { "Haus", "Maus", "ABC" };
            wörter.Where<string>(s => s.Length >= 4).ToList().ForEach(s => Console.WriteLine(s));
            Console.WriteLine($"Wort mit 3 Zeichen:  {wörter.ToList().Find(s => s.Length == 3)}");


            Dictionary<string, List<string>> Einwohenrverzeichnis = new Dictionary<string, List<string>>();
            Einwohenrverzeichnis.Add("Leipzig", new List<string>() { "Robert" });
            Einwohenrverzeichnis["Leipzig"].Add("Alex");

            Einwohenrverzeichnis.Add("Leipzig", "Anna");
            Einwohenrverzeichnis.Add("Köln", "Sebastian");


           
        }
    }
}
