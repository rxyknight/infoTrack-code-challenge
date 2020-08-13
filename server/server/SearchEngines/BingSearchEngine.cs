using RestSharp;
using server.Interfaces;


namespace server.SearchEngines
{
    public class BingSearchEngine : IBingSearchEngine
    {
        public const string BASE_ENDPOINT = "https://infotrack-tests.infotrack.com.au/Bing";

        public string Search(string keywords, int pageNumber)
        {
            var endPoint = $"{BASE_ENDPOINT}/Page{pageNumber.ToString("D2")}.html";
            var client = new RestClient(endPoint);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
