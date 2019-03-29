using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookContracts
{
    public interface IWebService
    {
        Task<IEnumerable<IBook>> SearchBooks(IBook searchParameters, IProgress<int> progress, CancellationToken token);
    }
}