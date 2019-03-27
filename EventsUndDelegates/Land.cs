using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates
{
    public class Land
    {
        public string Hauptstadt { get; set; }
        public int Einwohner { get; set; }

        public Land(string hauptstadt, int einwohner)
        {
            Hauptstadt = hauptstadt;
            Einwohner = einwohner;
        }

        public override string ToString()
        {
            return $"{Hauptstadt} ({Einwohner} Einwohner)";
        }
    }
}