using DiyCmDataModel.Construction;
using DiyCmWebAPI;
using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DiyCmWebApi.Test.Controllers
{
    public class ProjectsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProjectsControllerTests()
        {
            // Arrange
            _server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("/api/projects");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("[{\"ProjectId\":100,\"ProjectName\":\"First Construction Project\",\"Description\":\"My first construction project with DIYCM\",\"ProjectedStartDate\":\"2016-05-16T00:00:00\",\"ActualStartDate\":\"2016-03-01T00:00:00\",\"ProjectedFinishDate\":\"2015-08-20T00:00:00\",\"ActualFinishDate\":\"0001-01-01T00:00:00\"},{\"ProjectId\":200,\"ProjectName\":\"Test Project\",\"Description\":\"Test Project\",\"ProjectedStartDate\":\"2016-09-10T00:00:00\",\"ActualStartDate\":\"2016-08-09T00:00:00\",\"ProjectedFinishDate\":\"2016-09-09T00:00:00\",\"ActualFinishDate\":\"2016-08-08T00:00:00\"}]",
                responseString);
        }
    }

}
