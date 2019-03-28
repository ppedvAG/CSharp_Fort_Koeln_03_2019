using BookContracts;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IBook
    {
        public string ID { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string[] Authors { get; private set; }

        public string CoverURL { get; private set; }

        public string PreviewURL { get; private set; }

        public bool IsFavorite { get; set; }

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