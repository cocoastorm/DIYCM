using DiyCmDataModel.Construction;
using DiyCmWebAPI;
using DiyCmWebAPI.Controllers;
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
    public class SupplierInvoiceDetailsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public SupplierInvoiceDetailsControllerTests()
        {
            //Arrange
            _server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<StartupTest>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Test_get()
        {
            // Arrange
            Utility.Utility.RefreshDatabase();

            SupplierInvoiceDetail supplierInvoiceDetail = new SupplierInvoiceDetail
            {
                SupplierInvoiceHeader = null,
                LineNumber = 0,
                PartNumber = "3DI34",
                PartDescription = "Drain Stopper",
                CategoryId = 170,
                Category = null,
                SubCategoryId = 80,
                SubCategory = null,
                AreaId = 0,
                Area = null,
                Quantity = 2,
                UnitPrice = 85,
                Notes = "Universal, rubber"
            };
            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(supplierInvoiceDetail);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //make a POST
            var postResponse = await _client.PostAsync("/api/supplierinvoicedetails", content);
            postResponse.EnsureSuccessStatusCode();

            // Act
            var getResponse = await _client.GetAsync("/api/supplierinvoicedetails");
            getResponse.EnsureSuccessStatusCode();
            var responseString = await getResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("[]",
                responseString);
        }
    }
}
