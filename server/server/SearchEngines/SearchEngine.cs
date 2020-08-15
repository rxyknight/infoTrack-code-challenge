using RestSharp;
using server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.SearchEngines
{
    public abstract class SearchEngine : ISearchEngine
    {
        public string BaseEndpoint { get; set; }

        public abstract void InitEndpoint();

        public virtual string Search(string keywords, int pageNumber)
        {
            InitEndpoint();
            var endPoint = $"{BaseEndpoint}/Page{pageNumber.ToString("D2")}.html";
            var client = new RestClient(endPoint);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
