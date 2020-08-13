using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace serverTest
{
    public class UnitTest1
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }

        public UnitTest1()
        {
            SetUpClient();
        }


        /// <summary>
        /// Test API
        /// Test Google
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test1Async()
        {
            // Test "infotrack.com.au"
            var response1 = await Client.GetAsync("/api/v1/ranking?keywords=online title search&url=infotrack.com.au&searchEngines=google");
            response1.StatusCode.Should().BeEquivalentTo(200);
            var realData1 = JsonConvert.DeserializeObject(response1.Content.ReadAsStringAsync().Result);
            var expectedData1 = JsonConvert.DeserializeObject("{\"google\":[1]}");
            realData1.Should().BeEquivalentTo(expectedData1);

            // Test "NSW"
            var response2 = await Client.GetAsync("/api/v1/ranking?keywords=online title search&url=NSW&searchEngines=google");
            response2.StatusCode.Should().BeEquivalentTo(200);
            var realData2 = JsonConvert.DeserializeObject(response2.Content.ReadAsStringAsync().Result);
            var expectedData2 = JsonConvert.DeserializeObject("{\"google\":[2,3,5,6,8,10,16]}");
            realData2.Should().BeEquivalentTo(expectedData2);
        }

        /// <summary>
        /// Test API
        /// Test Bing
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test2Async()
        {
            // Test "infotrack.com.au"
            var response1 = await Client.GetAsync("/api/v1/ranking?keywords=online title search&url=infotrack.com.au&searchEngines=bing");
            response1.StatusCode.Should().BeEquivalentTo(200);
            var realData1 = JsonConvert.DeserializeObject(response1.Content.ReadAsStringAsync().Result);
            var expectedData1 = JsonConvert.DeserializeObject("{\"bing\":[28]}");
            realData1.Should().BeEquivalentTo(expectedData1);

            // Test "NSW"
            var response2 = await Client.GetAsync("/api/v1/ranking?keywords=online title search&url=NSW&searchEngines=bing");
            response2.StatusCode.Should().BeEquivalentTo(200);
            var realData2 = JsonConvert.DeserializeObject(response2.Content.ReadAsStringAsync().Result);
            var expectedData2 = JsonConvert.DeserializeObject("{\"bing\":[4,6,7,8,10,17,18,25,27,39,47]}");
            realData2.Should().BeEquivalentTo(expectedData2);
        }



        /// <summary>
        /// Test API
        /// Test Google and Bing
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test3Async()
        {
            // Test "infotrack.com.au"
            var response1 = await Client.GetAsync("/api/v1/ranking?keywords=online title search&url=infotrack.com.au&searchEngines=google,bing");
            response1.StatusCode.Should().BeEquivalentTo(200);
            var realData1 = JsonConvert.DeserializeObject(response1.Content.ReadAsStringAsync().Result);
            var expectedData1 = JsonConvert.DeserializeObject("{\"google\":[1],\"bing\":[28]}");
            realData1.Should().BeEquivalentTo(expectedData1);

            // Test "NSW"
            var response2 = await Client.GetAsync("/api/v1/ranking?keywords=online title search&url=NSW&searchEngines=google,bing");
            response2.StatusCode.Should().BeEquivalentTo(200);
            var realData2 = JsonConvert.DeserializeObject(response2.Content.ReadAsStringAsync().Result);
            var expectedData2 = JsonConvert.DeserializeObject("{\"google\":[2,3,5,6,8,10,16],\"bing\":[4,6,7,8,10,17,18,25,27,39,47]}");
            realData2.Should().BeEquivalentTo(expectedData2);
        }

        private void SetUpClient()
        {

            var builder = new WebHostBuilder()
                .UseStartup<server.Startup>();

            _server = new TestServer(builder);

            Client = _server.CreateClient();
        }
    }
}
