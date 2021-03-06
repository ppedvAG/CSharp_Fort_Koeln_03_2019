﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookLibrary
{
    //http://json2csharp.com/ 

    public class GoogleBooksAPIResult
    {
        [JsonProperty("items")]
        public BookResult[] books { get; set; }
    }

    public class BookResult
    {
        public string id { get; set; }
        public Volumeinfo volumeInfo { get; set; }
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string description { get; set; }
        public Imagelinks imageLinks { get; set; }
        public string previewLink { get; set; }
    }

    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
    }
}
