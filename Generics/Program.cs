using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericHistory();
            BeipieleFÜrGenerischeDatentypen();
            MyListTEst();
        }

        private static void MyListTEst()
        {
            MyList<int> liste = new MyList<int>();
            liste.Add(20);
            liste.Add(30);
            //liste.Add("adasd");
            Console.WriteLine(liste[0]);
            liste[1] = 100;

            for (int i = 0; i < liste.Anzahl; i++)
            {
                Console.WriteLine(liste[i]);
            }

            foreach (var item in liste)
            {
                Console.WriteLine(item);
            }
        }

        private static void BeipieleFÜrGenerischeDatentypen()
        {
            Dictionary<string, int> stadtEinwohnerTabelle = new Dictionary<string, int>();
            stadtEinwohnerTabelle.Add("Köln", 1_100_000);
            stadtEinwohnerTabelle.Add("Leipzig", 600_000);

            foreach (var item in stadtEinwohnerTabelle)
            {
                Console.WriteLine(item.Value);
            }

            Tuple<string, int> köln = new Tuple<string, int>("Köln", 1_100_000);
            
            List<(string Stadtname, int Einwohner)> städteListe = new List<(string Stadtname, int Einwohner)>();
            städteListe.Add(("Köln", 1_100_000));
            Console.WriteLine(städteListe[0].Stadtname);
            string json = "aaaaa";
            JsonConvert.DeserializeObject<List<string>>(json);

            //DbSet<Person>

            //Generischer Delegate-Typ
            Func<int, int> methodeMitIntParameterUndRückgabewertInt = Addiere;
            Console.WriteLine(methodeMitIntParameterUndRückgabewertInt(5));

            Queue<string> warteschlange = new Queue<string>();
            warteschlange.Enqueue("1. Person");
            warteschlange.Enqueue("2. Person");
            warteschlange.Enqueue("3. Person");

            //1. Person
            string ersterEintrag = warteschlange.Dequeue();

            Stack<string> personenHaufen = new Stack<string>();
            personenHaufen.Push("1. Person");
            personenHaufen.Push("2. Person");
            personenHaufen.Push("3. Person");
            //3. Person
            string letzterEintrag = personenHaufen.Pop();

        }

        private static int Addiere(int arg)
        {
            return arg * 2;
        }

        private static void GenericHistory()
        {
            int[] zahlen = new int[] { 2, 5, 4 };
            int[] zahlen2 = zahlen;
            zahlen[0] = 10;

            ArrayList zahlenListe = new ArrayList();
            zahlenListe.Add(5);
            zahlenListe.Add(4);
            zahlenListe.Add(1);
            zahlenListe.Add("test");
            zahlenListe.Add(false);

            int summe = 0;
            foreach (var irgendeinObjekt in zahlenListe)
            {
                //Unboxing
                if(irgendeinObjekt is int zahlInt)
                {
                    summe += zahlInt;
                }
            }
            Console.WriteLine($"Summe: {summe}");

            int z = 3;
            int z2 = z;
            z = 5;

            string wort = "asdasdasd";
            string wort2 = wort;

            ValueType werteTyp = z;
            //Boxing
            object irgendwas = z;

            List<int> zahlenListeGenerisch = new List<int>();
            zahlenListeGenerisch.Add(5);
            zahlenListeGenerisch.Add(10);
            foreach (var item in zahlenListeGenerisch)
            {
                summe += item;
            }
        }
    }

}
