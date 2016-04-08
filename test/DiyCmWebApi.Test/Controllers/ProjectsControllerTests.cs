using DiyCmDataModel.Construction;
using DiyCmWebAPI;
using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Xunit;

namespace DiyCmWebApi.Test.Controllers
{
    public class ProjectsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProjectsControllerTests()
        {
            //Arrange
            _server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<StartupTest>());
            _client = _server.CreateClient();
            //_client.DefaultRequestHeaders.Clear();
            //_client.DefaultRequestHeaders.Add("ContentType", "application/json");
        }

        [Fact]
        public async Task Test_get()
        {
            // Arrange
            Utility.Utility.RefreshDatabase();

            Project project1 = new Project
            {
                ProjectName = "Test Project",
                Description = "Test Description",
                ProjectedStartDate = new DateTime(2016, 1, 1),
                ActualStartDate = new DateTime(2016, 1, 1),
                ProjectedFinishDate = new DateTime(2016, 1, 1),
                ActualFinishDate = new DateTime(2016, 1, 1)
            };
            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(project1);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //make a POST
            var postResponse = await _client.PostAsync("/api/projects", content);
            postResponse.EnsureSuccessStatusCode();

            // Act
            var getResponse = await _client.GetAsync("/api/projects");
            getResponse.EnsureSuccessStatusCode();
            var responseString = await getResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("[{\"ProjectId\":1,\"ProjectName\":\"Test Project\",\"Description\":\"Test Description\",\"ProjectedStartDate\":\"2016-01-01T08:00:00\",\"ActualStartDate\":\"2016-01-01T08:00:00\",\"ProjectedFinishDate\":\"2016-01-01T08:00:00\",\"ActualFinishDate\":\"2016-01-01T08:00:00\"}]",
                responseString);
        }

        [Fact]
        public async Task Test_post()
        {
            // Arrange
            Utility.Utility.RefreshDatabase();

            Project project1 = new Project
            {
                ProjectName = "Test Project",
                Description = "Test Description",
                ProjectedStartDate = new DateTime(2016, 1, 1),
                ActualStartDate = new DateTime(2016, 1, 1),
                ProjectedFinishDate = new DateTime(2016, 1, 1),
                ActualFinishDate = new DateTime(2016, 1, 1)
            };
            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();      
            string jsonString = javaScriptSerializer.Serialize(project1);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Arrange
            var response = await _client.PostAsync("/api/projects", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("{\"ProjectId\":1,\"ProjectName\":\"Test Project\",\"Description\":\"Test Description\",\"ProjectedStartDate\":\"2016-01-01T08:00:00Z\",\"ActualStartDate\":\"2016-01-01T08:00:00Z\",\"ProjectedFinishDate\":\"2016-01-01T08:00:00Z\",\"ActualFinishDate\":\"2016-01-01T08:00:00Z\"}",
                responseString);
        }

        [Fact]
        public async Task Test_delete()
        {
            // Arrange
            Utility.Utility.RefreshDatabase();

            Project project1 = new Project
            {
                ProjectName = "Test Project",
                Description = "Test Description",
                ProjectedStartDate = new DateTime(2016, 1, 1),
                ActualStartDate = new DateTime(2016, 1, 1),
                ProjectedFinishDate = new DateTime(2016, 1, 1),
                ActualFinishDate = new DateTime(2016, 1, 1)
            };
            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(project1);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //make a POST
            var postResponse = await _client.PostAsync("/api/projects", content);
            postResponse.EnsureSuccessStatusCode();

            // Act
            var deleteResponse = await _client.DeleteAsync("api/projects/1");    //delete the first item
            deleteResponse.EnsureSuccessStatusCode();
            var responseString = await deleteResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("{\"ProjectId\":1,\"ProjectName\":\"Test Project\",\"Description\":\"Test Description\",\"ProjectedStartDate\":\"2016-01-01T08:00:00\",\"ActualStartDate\":\"2016-01-01T08:00:00\",\"ProjectedFinishDate\":\"2016-01-01T08:00:00\",\"ActualFinishDate\":\"2016-01-01T08:00:00\"}",
                responseString);
        }
    }
}
