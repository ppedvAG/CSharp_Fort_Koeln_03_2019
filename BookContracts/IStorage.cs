using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContracts
{
    public interface IStorage
    {
        void SaveBooks(IEnumerable<IBook> books);
        IEnumerable<IBook> LoadBooks();
    }
}