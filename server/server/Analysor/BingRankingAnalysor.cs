using server.Extensions;
using server.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace server.Analysor
{
    public class BingRankingAnalysor : RankingAnalysor
    {
        public BingRankingAnalysor(ISearchEngine _searchEngine) : base(_searchEngine)
        {

        }

        public override string StartTag()
        {
            return "<li class=\"b_algo\">";
        }
        public override string EndTag()
        {
            return "<aside aria-label=\"Additional Results\">";
        }

    }
}
