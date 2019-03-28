using BookContracts;
using BookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksClient
{
    public static class GlobalModules
    {
        private static IWebService _webService;
        //Abwandlung des Singleton-Prinzips
        public static IWebService WebService
        {
            get
            {
                if(_webService == null)
                {
                    _webService = new WebService();
                }
                return _webService;
            }
        }

        private static IFavoriteManager _favoriteManager;
        public static IFavoriteManager FavoriteManager => _favoriteManager ?? (_favoriteManager = new FavoriteManager(Storage));

        private static IStorage _storage;
        public static IStorage Storage => _storage ?? (_storage = new Storage());

        public static List<IPlugin> Plugins = new List<IPlugin>();

    }
}
