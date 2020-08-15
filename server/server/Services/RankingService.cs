using Microsoft.AspNetCore.Hosting.Builder;
using server.Analysor;
using server.Factories;
using server.Interfaces;
using server.SearchEngines;
using System;
using System.Collections.Generic;

namespace server.Services
{
    public class RankingService : IRankingService
    {
        public RankingService()
        {

        }
        public Dictionary<string, List<int>> GetRankingResult(string keywords, string url, List<string> searchEngineTypes)
        {
            var results = new Dictionary<string, List<int>>();
            searchEngineTypes.ForEach(type =>
            {
                IRankingAnalysor rankingAnalysor = RankingAnalysorFactory.Create(type);
                results[type] = rankingAnalysor.Analyse(keywords, url);
            });
            return results;
        }
    }
}
