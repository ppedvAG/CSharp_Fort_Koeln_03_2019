using BookContracts;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IBook
    {
        [IgnoreForSorting]
        public string ID { get; private set; }

        [SortingDescription("Titel")]
        public string Title { get; private set; }

        [SortingDescription("Beschreibung")]
        public string Description { get; private set; }

        [SortingDescription("Autoren")]
        public string[] Authors { get; private set; }

        [IgnoreForSorting]
        public string CoverURL { get; private set; }

        [IgnoreForSorting]
        public string PreviewURL { get; private set; }

        [SortingDescription("Favoriten")]
        public bool IsFavorite { get; set; }

        [JsonConstructor]
        public Book(string iD, string title, string description, string[] authors, string coverURL, string previewURL, bool isFavorite = false)
        {
            ID = iD;
            Title = title;
            Description = description;
            Authors = authors;
            CoverURL = coverURL;
            PreviewURL = previewURL;
            IsFavorite = isFavorite;
        }
        
        public Book(string title)
        {
            Title = title;
        }
    }
}