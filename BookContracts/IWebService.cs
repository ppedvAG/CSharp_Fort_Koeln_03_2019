using System.Collections.Generic;

namespace BookContracts
{
    public interface IWebService
    {
        IEnumerable<IBook> SearchBooks(IBook searchParameters);
    }
}