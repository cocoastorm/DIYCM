using DiyCmDataModel.Construction;
using DiyCmWebAPI;
using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Xunit;

namespace DiyCmWebApi.Test.Controllers
{
    public class AreasControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AreasControllerTests()
        {
            //Arrange
            _server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<StartupTest>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Test_get()
        {
            //Arrange
            Utility.Utility.RefreshDatabase();

            Area a = new Area
            {
                AreaRoom = "Kitchen",
                AreaSquareFootage = 222.22m
            };

            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(a);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //make a POST
            var postResponse = await _client.PostAsync("/api/areas", content);
            postResponse.EnsureSuccessStatusCode();

            // Act
            var getResponse = await _client.GetAsync("/api/areas");
            getResponse.EnsureSuccessStatusCode();
            var responseString = await getResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("[{\"AreaId\":1,\"AreaRoom\":\"Kitchen\",\"AreaSquareFootage\":222.22}]",
                responseString);
        }

        [Fact]
        public async Task Test_post()
        {
            //Arrange
            Utility.Utility.RefreshDatabase();

            Area a = new Area
            {
                AreaRoom = "Kitchen",
                AreaSquareFootage = 222.22m
            };

            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(a);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            //make a POST
            var postResponse = await _client.PostAsync("/api/areas", content);
            postResponse.EnsureSuccessStatusCode();
            var responseString = await postResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("{\"AreaId\":1,\"AreaRoom\":\"Kitchen\",\"AreaSquareFootage\":222.22}",
                responseString);
        }

        [Fact]
        public async Task Test_delete()
        {
            //Arrange
            Utility.Utility.RefreshDatabase();

            Area a = new Area
            {
                AreaRoom = "Kitchen",
                AreaSquareFootage = 222.22m
            };

            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(a);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //make a POST
            var postResponse = await _client.PostAsync("/api/areas", content);
            postResponse.EnsureSuccessStatusCode();

            // Act
            var deleteResponse = await _client.DeleteAsync("api/areas/1");    //delete the first item
            deleteResponse.EnsureSuccessStatusCode();
            var responseString = await deleteResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("{\"AreaId\":1,\"AreaRoom\":\"Kitchen\",\"AreaSquareFootage\":222.22}",
                responseString);
        }

    }
}
