using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContracts
{
    public interface IPlugin
    {
        /// <summary>
        /// Manipuliert/Erweitert den BookPresenter
        /// </summary>
        /// <param name="collection">Container für die Steuerelemente</param>
        /// <param name="book">Das darzustellende Buch</param>
        void AddOtherControls(object collection, IBook book);
        //Für Lokalisierung
        //string GetLabel(CultureInfo info);
    }
}
