using DiyCmDataModel.Construction;
using DiyCmWebAPI;
using Microsoft.AspNet.TestHost;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Xunit;

namespace DiyCmWebApi.Test.Controllers
{
    public class QuoteHeadersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public QuoteHeadersControllerTests()
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

            string date = new DateTime(2016, 4, 8, 16, 5, 0).ToString("s");
            string expected = "[{\"QuoteHeaderId\":1,\"Supplier\":\"Alpha Supplier\",\"Date\":\"2016-04-08T23:05:00\",\"StartDate\":\"2016-04-08T23:05:00\",\"ReferredBy\":\"Customer1\",\"AddressStreet\":\"Kingsway\",\"AddressCity\":\"Vancouver\",\"AddressProvince\":\"BC\",\"AddressPostalCode\":\"VLNK90\",\"AddressCountry\":\"Canada\",\"ExpiryDate\":\"2016-04-08T23:05:00\",\"PercentDiscount\":20.0,\"notes\":\"priority\",\"IsAccept\":\"Y\",\"ContactName\":\"Customer1\",\"PhoneNumber\":\"604123456\"}]";


            QuoteHeader q = new QuoteHeader
            {
                QuoteHeaderId = 1,
                Supplier = "Alpha Supplier",
                Date = new DateTime(2016, 4, 8, 16, 5, 0),
                StartDate = new DateTime(2016, 4, 8, 16, 5, 0),
                ReferredBy = "Customer1",
                AddressStreet = "Kingsway",
                AddressCity = "Vancouver",
                AddressProvince = "BC",
                AddressPostalCode = "VLNK90",
                AddressCountry = "Canada",
                ExpiryDate = new DateTime(2016, 4, 8, 16, 5, 0),
                PercentDiscount = 20,
                notes = "priority",
                IsAccept = 'Y',
                ContactName = "Customer1",
                PhoneNumber = "604123456",
            };

            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(q);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //make a POST
            var postResponse = await _client.PostAsync("/api/QuoteHeaders", content);
            postResponse.EnsureSuccessStatusCode();

            // Act 
            var getResponse = await _client.GetAsync("/api/quoteheaders");
            getResponse.EnsureSuccessStatusCode();
            var responseString = await getResponse.Content.ReadAsStringAsync();

            Assert.Equal(expected, responseString);

        }

        [Fact]
        public async Task Test_post()
        {
            //Arrange
            Utility.Utility.RefreshDatabase();
            string expected = "{\"QuoteHeaderId\":1,\"Supplier\":\"Alpha Supplier\",\"Date\":\"2016-04-08T23:05:00Z\",\"StartDate\":\"2016-04-08T23:05:00Z\",\"ReferredBy\":\"Customer1\",\"AddressStreet\":\"Kingsway\",\"AddressCity\":\"Vancouver\",\"AddressProvince\":\"BC\",\"AddressPostalCode\":\"VLNK90\",\"AddressCountry\":\"Canada\",\"ExpiryDate\":\"2016-04-08T23:05:00Z\",\"PercentDiscount\":20.0,\"notes\":\"priority\",\"IsAccept\":\"Y\",\"ContactName\":\"Customer1\",\"PhoneNumber\":\"604123456\"}";

            QuoteHeader q = new QuoteHeader
            {
                QuoteHeaderId = 1,
                Supplier = "Alpha Supplier",
                Date = new DateTime(2016, 4, 8, 16, 5, 0),
                StartDate = new DateTime(2016, 4, 8, 16, 5, 0),
                ReferredBy = "Customer1",
                AddressStreet = "Kingsway",
                AddressCity = "Vancouver",
                AddressProvince = "BC",
                AddressPostalCode = "VLNK90",
                AddressCountry = "Canada",
                ExpiryDate = new DateTime(2016, 4, 8, 16, 5, 0),
                PercentDiscount = 20,
                notes = "priority",
                IsAccept = 'Y',
                ContactName = "Customer1",
                PhoneNumber = "604123456",
            };

            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(q);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            //make a POST
            var postResponse = await _client.PostAsync("/api/QuoteHeaders", content);
            postResponse.EnsureSuccessStatusCode();
            var responseString = await postResponse.Content.ReadAsStringAsync();


            Assert.Equal(expected, responseString);
        }

        [Fact]
        public async Task Test_delete()
        {
            //Arrange
            Utility.Utility.RefreshDatabase();
            string date = new DateTime(2016, 4, 8, 16, 5, 0).ToString("s");
            string expected = "{\"QuoteHeaderId\":1,\"Supplier\":\"Alpha Supplier\",\"Date\":\"2016-04-08T23:05:00\",\"StartDate\":\"2016-04-08T23:05:00\",\"ReferredBy\":\"Customer1\",\"AddressStreet\":\"Kingsway\",\"AddressCity\":\"Vancouver\",\"AddressProvince\":\"BC\",\"AddressPostalCode\":\"VLNK90\",\"AddressCountry\":\"Canada\",\"ExpiryDate\":\"2016-04-08T23:05:00\",\"PercentDiscount\":20.0,\"notes\":\"priority\",\"IsAccept\":\"Y\",\"ContactName\":\"Customer1\",\"PhoneNumber\":\"604123456\"}";

            QuoteHeader q = new QuoteHeader
            {
                QuoteHeaderId = 1,
                Supplier = "Alpha Supplier",
                Date = new DateTime(2016, 4, 8, 16, 5, 0),
                StartDate = new DateTime(2016, 4, 8, 16, 5, 0),
                ReferredBy = "Customer1",
                AddressStreet = "Kingsway",
                AddressCity = "Vancouver",
                AddressProvince = "BC",
                AddressPostalCode = "VLNK90",
                AddressCountry = "Canada",
                ExpiryDate = new DateTime(2016, 4, 8, 16, 5, 0),
                PercentDiscount = 20,
                notes = "priority",
                IsAccept = 'Y',
                ContactName = "Customer1",
                PhoneNumber = "604123456",
            };

            //convert object to StringContent for POST
            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(q);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //make a POST
            var postResponse = await _client.PostAsync("/api/quoteheaders", content);
            postResponse.EnsureSuccessStatusCode();

            // Act
            var deleteResponse = await _client.DeleteAsync("api/quoteheaders/1");    //delete the first item
            deleteResponse.EnsureSuccessStatusCode();
            var responseString = await deleteResponse.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expected,
                responseString);
        }
    }
}