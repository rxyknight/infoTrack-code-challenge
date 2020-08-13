using System.Collections.Generic;

namespace server.Interfaces
{
    public interface IRankingAnalysor
    {
        List<int> Analyse(string keywords, string url);
    }
}