using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class MyList<InternalArrayType> : IEnumerable<InternalArrayType>
    {
        InternalArrayType[] _internesArray = new InternalArrayType[0];
        int _anzahlElemente = 0;

        public void Add(InternalArrayType neuesElement)
        {

            InternalArrayType[] copy = new InternalArrayType[_anzahlElemente + 1];
            if (_anzahlElemente > 0)
            {
                Array.Copy(_internesArray, copy, _anzahlElemente);
            }
            copy[_anzahlElemente] = neuesElement;
            _internesArray = copy;
            _anzahlElemente++;
        }

        public IEnumerator GetEnumerator()
        {
            return _internesArray.GetEnumerator();

            //yield return "asdsdasdsa";
            //yield return _internesArray[0];

            //foreach (var item in _internesArray)
            //{
            //    yield return item;
            //}
        }

        IEnumerator<InternalArrayType> IEnumerable<InternalArrayType>.GetEnumerator()
        {
            foreach (var item in _internesArray)
            {
                if(item is InternalArrayType internalType)
                {
                    yield return item;
                }
            }
        }

        public InternalArrayType this[int index]
        {
            get
            {
                return _internesArray[index];
            }
            set
            {
                _internesArray[index] = value;
            }
        }

        public int Anzahl
        {
            get
            {
                return _internesArray.Length;
            }
        }

    }
}