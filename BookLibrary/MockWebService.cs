using BookContracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class MockWebService : IWebService
    {
        public async Task<IEnumerable<IBook>> SearchBooks(IBook searchParameters, IProgress<int> progress, CancellationToken token)
        {

            #region Alternative ohne await
            //return Task.FromResult<IEnumerable<IBook>>(new List<IBook>()
            //{
            //    new Book(
            //            iD: "asdij3231",
            //            title: "Titl1",
            //            description: "Beschreiung des Buches",
            //            authors: new string[] { "Autor1", "Autor2" },
            //            coverURL: "http://www.quatsch.de",
            //            previewURL: "http://www.previewquatsch.de"),
            //    new Book(
            //            iD: "aaadabd",
            //            title: "Titl2",
            //            description: "Beschreiung des 2. Buches",
            //            authors: new string[] { "Anderer Autor" },
            //            coverURL: "http://www.quatsch2.de",
            //            previewURL: "http://www.previewquatsch2.de"),
            //});
            #endregion


            await Task.Delay(0);
            return new List<IBook>()
            {
                new Book(
                        iD: "asdij3231", 
                        title: "Titl1", 
                        description: "Beschreiung des Buches", 
                        authors: new string[] { "Autor1", "Autor2" }, 
                        coverURL: "http://www.quatsch.de", 
                        previewURL: "http://www.previewquatsch.de"),
                new Book(
                        iD: "aaadabd",
                        title: "Titl2",
                        description: "Beschreiung des 2. Buches",
                        authors: new string[] { "Anderer Autor" },
                        coverURL: "http://www.quatsch2.de",
                        previewURL: "http://www.previewquatsch2.de"),
            };
        }
    }
}