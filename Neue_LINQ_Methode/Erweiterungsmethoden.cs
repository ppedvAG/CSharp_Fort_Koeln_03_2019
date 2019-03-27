using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neue_LINQ_Methode.Erweiterung
{
    public static class Erweiterungsmethoden
    {
        public static int Quersumme(this int zahl)
        {
            string ziffern = zahl.ToString();
            int summe = 0;
            foreach (var item in ziffern)
            {
                summe += (int)char.GetNumericValue(item);
            }
            return summe;
        }

        public static string Verdoppeln(this string wort, string trennzeichen)
        {
            return wort + trennzeichen + wort;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Add<Key, Value, ListItem>(this Dictionary<Key, Value> dictionary, Key key, ListItem value) where Value : ICollection<ListItem>, new()
        {
            if(dictionary.ContainsKey(key))
            {
                dictionary[key].Add(value);
            }
            else
            {
                Value newList = new Value();
                newList.Add(value);
                dictionary.Add(key, newList);
            }
        }
    }
}
