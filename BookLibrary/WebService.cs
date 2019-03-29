using BookContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class WebService : IWebService
    {
        public async Task<IEnumerable<IBook>> SearchBooks(IBook searchParameters, IProgress<int> progress, CancellationToken token)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(30);
                string json = await client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=" + searchParameters.Title.Replace(" ", "+"));
                token.ThrowIfCancellationRequested();
                //Progress erhöhen
                progress.Report(30);
                //nicht mit Sleep warten,denn alles nach dem await wird auf dem Haupt-Thread ausgeführt (invoked)
                await Task.Delay(1000);
                token.ThrowIfCancellationRequested();
                progress.Report(50);
                await Task.Delay(1000);
                token.ThrowIfCancellationRequested();
                progress.Report(70);
                await Task.Delay(1000);
                token.ThrowIfCancellationRequested();
                progress.Report(90);

                //Deserialisieren
                var apiResults = JsonConvert.DeserializeObject<GoogleBooksAPIResult>(json);
                token.ThrowIfCancellationRequested();

                List<IBook> bookResults = new List<IBook>();
                foreach (var book in apiResults.books)
                {
                    string id = book?.id;
                    string title = book?.volumeInfo?.title;
                    string description = book?.volumeInfo?.description;
                    string[] authors = book?.volumeInfo?.authors;
                    string coverURL = book?.volumeInfo?.imageLinks?.smallThumbnail;
                    string previewLink = book?.volumeInfo?.previewLink;

                    Book newBook = new Book(id, title, description, authors, coverURL, previewLink);
                    bookResults.Add(newBook);
                }
                token.ThrowIfCancellationRequested();
                progress.Report(100);
                return bookResults;
            }
            catch (OperationCanceledException exp)
            {
                return new List<IBook>();
            }
        }
    }
}