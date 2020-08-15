
namespace server.SearchEngines
{
    public class GoogleSearchEngine : SearchEngine
    {
        public override void InitEndpoint()
        {
            BaseEndpoint = "https://infotrack-tests.infotrack.com.au/Google";
        }

    }
}
