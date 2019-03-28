using BookContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Storage : IStorage
    {
        const string File_Name = "MyFavoriteBooks.mfb";
        JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            //Schreibe die Namen der Datentypen mit in den serialisierten String hinein.
            //Ansonsten weiß der Deserialisierer später nicht, welche Klasse er IBook instantiieren soll
            TypeNameHandling = TypeNameHandling.Objects
        };
        
        public IEnumerable<IBook> LoadBooks()
        {
            if(File.Exists(File_Name))
            {
                string json = File.ReadAllText(File_Name, Encoding.Default);
                return JsonConvert.DeserializeObject<List<IBook>>(json, _settings);
            }
            return new List<IBook>();
        }

        public void SaveBooks(IEnumerable<IBook> books)
        {
            string json = JsonConvert.SerializeObject(books.ToList(), _settings);
            File.WriteAllText(File_Name, json,Encoding.Default);
        }
    }
}