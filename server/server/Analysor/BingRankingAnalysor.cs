using server.Extensions;
using server.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace server.Analysor
{
    public class BingRankingAnalysor : IBingRankingAnalysor
    {
        private readonly IBingSearchEngine _searchEngine;

        public BingRankingAnalysor(IBingSearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }

        public List<int> Analyse(string keywords, string url)
        {
            var rankingResults = new List<int>();
            if (string.IsNullOrEmpty(keywords) || string.IsNullOrEmpty(url))
            {
                rankingResults.Add(0);
                return rankingResults;
            }
            int currentPageNumber = 1;
            string searchResult = _searchEngine.Search(keywords, currentPageNumber);
            var indexList = searchResult.AllIndexesOf("<li class=\"b_algo\">");
            indexList.Add(searchResult.IndexOf("<aside aria-label=\"Additional Results\">"));
            var resultList = new List<string>();
            for (var i = 0; i < indexList.Count() - 1; i++)
            {
                resultList.Add(searchResult.Substring(indexList[i], indexList[i + 1] - indexList[i] + 1));
            }
            while (resultList.Count < 50)
            {
                currentPageNumber++;
                searchResult = _searchEngine.Search(keywords, currentPageNumber);
                indexList = searchResult.AllIndexesOf("<li class=\"b_algo\">");
                indexList.Add(searchResult.IndexOf("<aside aria-label=\"Additional Results\">"));
                if (indexList.Count < 2) break;
                for (var i = 0; i < indexList.Count() - 1; i++)
                {
                    if(resultList.Count < 50)
                    {
                        resultList.Add(searchResult.Substring(indexList[i], indexList[i + 1] - indexList[i] + 1));
                    }
                }
            }
            for (var i = 0; i < resultList.Count; i++)
            {
                if (resultList[i].IndexOf(url) != -1)
                {
                    rankingResults.Add(i + 1);
                }
            }
            if (rankingResults.Count == 0)
            {
                rankingResults.Add(0);
            }
            return rankingResults;
        }
    }
}
