using BookContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class MockStorage : IStorage
    {
        public IEnumerable<IBook> LoadBooks()
        {
            return new List<IBook>()
            {
                new Book(
                        iD: "bbbb",
                        title: "Favorit",
                        description: "Beschreiung des Favoriten-Buches",
                        authors: new string[] { "Autor1", "Autor2" },
                        coverURL: "http://www.quatsch.de",
                        previewURL: "http://www.previewquatsch.de",
                        isFavorite: true)
            };
        }

        public void SaveBooks(IEnumerable<IBook> books)
        {
            
        }
    }
}
