using BookContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class WebService : IWebService
    {
        public IEnumerable<IBook> SearchBooks(IBook searchParameters)
        {
            //TODO: Try/Catch
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            string json = client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=" + searchParameters.Title.Replace(" ", "+")).Result;

            //Deserialisieren
            var apiResults = JsonConvert.DeserializeObject<GoogleBooksAPIResult>(json);

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
            return bookResults;
        }
    }
}