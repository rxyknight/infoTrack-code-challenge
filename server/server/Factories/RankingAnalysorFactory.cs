using server.Analysor;
using server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Factories
{
    public class RankingAnalysorFactory
    {
        public static IRankingAnalysor Create(string type)
        {
            if(type == "google")
            {
                return new GoogleRankingAnalysor(SearchEngineFactory.Create("google"));
            }else
            {
                return new BingRankingAnalysor(SearchEngineFactory.Create("bing"));
            }
        }
    }
}
