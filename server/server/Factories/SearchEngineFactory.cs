using server.Interfaces;
using server.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Factories
{
    public class SearchEngineFactory
    {
        public static ISearchEngine Create(string type)
        {
            if(type == "google")
            {
                return new GoogleSearchEngine();
            }
            else
            {
                return new BingSearchEngine();
            }
        }
    }
}
