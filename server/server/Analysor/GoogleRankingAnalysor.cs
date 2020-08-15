using server.Extensions;
using server.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace server.Analysor
{
    public class GoogleRankingAnalysor : RankingAnalysor
    {

        public GoogleRankingAnalysor(ISearchEngine searchEngine): base(searchEngine)
        {

        }

        public override string StartTag()
        {
            return "<div class=\"g\">";
        }

        public override string EndTag()
        {
            return "<div id=\"bottomads\">";
        }

    }
}
