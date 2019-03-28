using BookContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class FavoriteManager : IFavoriteManager
    {
        private List<IBook> _favoriteBooks;
        private IStorage _storage;

        //Expression Body Member
        public IEnumerable<IBook> FavoriteBooks => new List<IBook>(_favoriteBooks);

        public bool PendingChanges { get; private set; }

        public FavoriteManager(IStorage storage)
        {
            _storage = storage;
            _favoriteBooks = _storage.LoadBooks().ToList();
        }

        public void MarkIfFavorite(IEnumerable<IBook> books)
        {
            foreach (var book in books)
            {
                if(_favoriteBooks.FirstOrDefault(b => b.ID == book.ID) != null) {
                    book.IsFavorite = true;
                }
            }
        }

        public void Save()
        {
            _storage.SaveBooks(_favoriteBooks);
            PendingChanges = false;
        }

        public bool ToggleFavoriteStatus(IBook book)
        {
            IBook bookInList = _favoriteBooks.FirstOrDefault(b => b.ID == book.ID);
            if(!book.IsFavorite)
            {
                book.IsFavorite = true;
                if (bookInList != null)
                {
                    return false;
                }
                _favoriteBooks.Add(book);
            }
            else
            {
                book.IsFavorite = false;
                if(bookInList == null)
                {
                    return false;
                }

                _favoriteBooks.Remove(bookInList);
            }
            PendingChanges = true;
            return true;
        }
    }
}
