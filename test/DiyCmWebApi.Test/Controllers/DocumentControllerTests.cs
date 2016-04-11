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
    public class DocumentControllerTests
    {
            private readonly TestServer _server;
            private readonly HttpClient _client;

            public DocumentControllerTests()
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

                Document d = new Document
                {
                    DocumentType = "Report",
                    Title = "2016 Financial Report"
                };

                //convert object to StringContent for POST
                var javaScriptSerializer = new JavaScriptSerializer();
                string jsonString = javaScriptSerializer.Serialize(d);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                //make a POST
                var postResponse = await _client.PostAsync("/api/documents", content);
                postResponse.EnsureSuccessStatusCode();

                // Act
                var getResponse = await _client.GetAsync("/api/documents");
                getResponse.EnsureSuccessStatusCode();
                var responseString = await getResponse.Content.ReadAsStringAsync();

                // Assert
                Assert.Equal("[{\"DocumentId\":1,\"DocumentType\":\"Report\",\"Title\":\"2016 Financial Report\"}]",
                    responseString);
            }

            [Fact]
            public async Task Test_post()
            {
                //Arrange
                Utility.Utility.RefreshDatabase();

                Document d = new Document
                {
                    DocumentType = "Report",
                    Title = "2016 Financial Report"
                };

                //convert object to StringContent for POST
                var javaScriptSerializer = new JavaScriptSerializer();
                string jsonString = javaScriptSerializer.Serialize(d);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                //Act
                //make a POST
                var postResponse = await _client.PostAsync("/api/documents", content);
                postResponse.EnsureSuccessStatusCode();
                var responseString = await postResponse.Content.ReadAsStringAsync();

                // Assert
                Assert.Equal("{\"DocumentId\":1,\"DocumentType\":\"Report\",\"Title\":\"2016 Financial Report\"}",
                    responseString);
            }
            [Fact]
            public async Task Test_delete()
            {
                //Arrange
                Utility.Utility.RefreshDatabase();

                Document d = new Document
                {
                    DocumentType= "Report",
                    Title = "2016 Financial Report"
                };

                //convert object to StringContent for POST
                var javaScriptSerializer = new JavaScriptSerializer();
                string jsonString = javaScriptSerializer.Serialize(d);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                //make a POST
                var postResponse = await _client.PostAsync("/api/documents", content);
                postResponse.EnsureSuccessStatusCode();

                // Act
                var deleteResponse = await _client.DeleteAsync("api/documents/1");    //delete the first item
                deleteResponse.EnsureSuccessStatusCode();
                var responseString = await deleteResponse.Content.ReadAsStringAsync();

                // Assert
                Assert.Equal("{\"DocumentId\":1,\"DocumentType\":\"Report\",\"Title\":\"2016 Financial Report\"}",
                    responseString);
            }

        }
     
}
