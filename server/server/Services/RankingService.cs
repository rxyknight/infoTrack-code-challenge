using server.Analysor;
using server.Interfaces;
using server.SearchEngines;
using System;
using System.Collections.Generic;

namespace server.Services
{
    public class RankingService : IRankingService
    {
        private IGoogleRankingAnalysor _googleRankingAnalysor;
        private IBingRankingAnalysor _bingRankingAnalysor;
        public RankingService(IGoogleRankingAnalysor googleRankingAnalysor,
            IBingRankingAnalysor bingRankingAnalysor)
        {
            _googleRankingAnalysor = googleRankingAnalysor;
            _bingRankingAnalysor = bingRankingAnalysor;
        }
        public Dictionary<string, List<int>> GetRankingResult(string keywords, string url, List<string> searchEngineTypes)
        {
            var results = new Dictionary<string, List<int>>();
            searchEngineTypes.ForEach(type =>
            {
                if (type == "google")
                {
                    results[type] = _googleRankingAnalysor.Analyse(keywords, url);
                }
                if (type == "bing")
                {
                    results[type] = _bingRankingAnalysor.Analyse(keywords, url);
                }
            });
            return results;
        }
    }
}
