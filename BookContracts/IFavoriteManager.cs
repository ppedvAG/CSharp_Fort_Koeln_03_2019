using System.Collections.Generic;

namespace BookContracts
{
    public interface IFavoriteManager
    {
        bool ToggleFavoriteStatus(IBook book);
        IEnumerable<IBook> FavoriteBooks { get; }
        void MarkIfFavorite(IEnumerable<IBook> books);
        void Save();
        bool PendingChanges { get; }
    }
}