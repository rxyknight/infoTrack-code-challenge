

namespace server.SearchEngines
{
    public class BingSearchEngine : SearchEngine
    {
        public override void InitEndpoint()
        {
            BaseEndpoint = "https://infotrack-tests.infotrack.com.au/Bing";
        }

    }
}
