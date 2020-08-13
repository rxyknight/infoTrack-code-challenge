using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IRankingService
    {
        Dictionary<string, List<int>> GetRankingResult(string keywords, string url, List<string> searchEngineTypes);
    }
}
