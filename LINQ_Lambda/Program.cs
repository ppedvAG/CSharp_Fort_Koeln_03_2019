using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autoliste = new List<Auto>()
            {
                new Auto("Audi", 5),
                new Auto("Toyota", 5, true),
                new Auto("Opel", 5, true),
                new Auto("Mercedes", 10),
                new Auto("Renault", 10),
                new Auto("BMW", 10, true)
            };

            //Liste von Delegate-Variablen anlegen und diese nacheinander aufrufen
            List<Action<List<Auto>>> methods = new List<Action<List<Auto>>>()
            {
                VarianteOhneLambda,
                VarianteMitLambda,
                VarianteMitLINQ,
                ViertesSzenario,
            };

            foreach (var item in methods)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{item.Method.Name} wird ausgeführt: \n");
                Console.ForegroundColor = ConsoleColor.White;
                item(autoliste);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-----------------------------------------------------");
            }


            Console.ReadKey();
        }

        private static void ViertesSzenario(List<Auto> autoliste)
        {
            
        }

        private static void VarianteMitLINQ(List<Auto> autoliste)
        {
            //Fluent-Design
            Console.WriteLine("Nicht-Elektroantrieb, sortiert nach Namen: ");
            autoliste.Where(auto => !auto.Elektroantrieb).OrderBy(auto => auto.Name).ToList().ForEach(auto => Console.WriteLine(auto));

            //nach Hubraum filtern und dann nach Elektroantrieb sortieren und in Konsole ausgeben
            Console.WriteLine("Hubraum größer 5, sortiert nach Elektroantrie: ");
            autoliste.Where(auto => auto.Hubraum > 5).OrderBy(auto => auto.Elektroantrieb).ToList().ForEach(auto => Console.WriteLine(auto));

        }

        private static void VarianteMitLambda(List<Auto> autoliste)
        {
            AutoFiltern(autoliste, (Auto auto) =>
            {
                if (auto.Name.Length > 4)
                {
                    return true;
                }
                return false;
            });

            AutoFiltern(autoliste, (Auto auto) =>
            {
                return auto.Name.Length > 4;
            });

            AutoFiltern(autoliste, (Auto auto) => auto.Name.Length > 4);
            var gefilterteAutos = AutoFiltern(autoliste, auto => auto.Name.Length > 4);
            foreach (var item in gefilterteAutos)
            {
                Console.WriteLine(item);
            }

            AutoFiltern(autoliste, auto => HubraumKrit(auto, 7));

        }


        public static bool HubraumKrit(Auto auto, int hubraum)
        {
            if (auto.Hubraum > hubraum)
            {
                return true;
            }
            return false;
        }

        #region Ohne Lambda
        private static void VarianteOhneLambda(List<Auto> autoliste)
        {
            //Filterung
            Console.WriteLine("Elektroautos: ");
            List<Auto> elektroautos = AutoFiltern(autoliste, HatElektroantrieb);
            foreach (var item in elektroautos)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Autos mit viel Hubraum: ");
            List<Auto> großerHubraum = AutoFiltern(autoliste, Hubraum);
            foreach (var item in großerHubraum)
            {
                Console.WriteLine(item);
            }
        }

        static bool HatElektroantrieb(Auto auto)
        {
            if (auto.Elektroantrieb)
            {
                return true;
            }
            return false;
        }

        static bool Hubraum(Auto auto)
        {
            if (auto.Hubraum > 5)
            {
                return true;
            }
            return false;
        }
        #endregion

        static List<Auto> AutoFiltern(List<Auto> autoListe, Func<Auto, bool> kriterium)
        {
            List<Auto> gefilterteListe = new List<Auto>();
            foreach (var auto in autoListe)
            {
                if (kriterium.Invoke(auto))
                {
                    gefilterteListe.Add(auto);
                }
            }
            return gefilterteListe;
        }
    }
}