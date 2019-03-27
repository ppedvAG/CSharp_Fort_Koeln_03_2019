using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates
{
    //🥨 (WindowsTaste-Punkt)
    public class Länderliste : BindingList<Land>
    {
        //Felder (Variablen)
        //Properties/Events

        public event EventHandler<string> Error;

        #region Ausformuliertes Event
        private EventHandler _ausprogrammiertesEvent;
        public event EventHandler AusprogrammiertesEvent
        {
            add
            {
                _ausprogrammiertesEvent += value;
            }
            remove
            {
                _ausprogrammiertesEvent -= value;
            }
        }
        #endregion

        public int? Limit { get; set; }

        //Konstruktor
        public Länderliste(int? limit = null)
        {
            Limit = limit;
        }

        //Methoden
        public new void Add(Land neuesLand)
        {
            if (Limit != null && base.Count >= Limit)
            {
                Error?.Invoke(this, "Limit wurde überschritten!");
                return;
            }

            //Verhindern dass 2 Hauptstädte doppelt vorkommen
            foreach (var item in this)
            {
                if (item.Hauptstadt.ToLower() == neuesLand.Hauptstadt.ToLower())
                {
                    Error?.Invoke(this, "Diese Haupstadt existiert schon!");
                    return;
                }
            }

            base.Add(neuesLand);
        }
    }
}