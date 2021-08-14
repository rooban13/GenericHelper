using FluentAssertions;
using GenericHelper.Core.Model;
using GenericHelper.Demo.Core.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace GenericHelper.Demo.IntegrationTests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class ProductTypeTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ProductTypeTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact, Priority(0)]
        public async Task GetEntitiesAsync_CountShouldBeZero()
        {
            // Arrange
            var request = "/api/producttypes";

            // Act
            var response = await Client.GetAsync(request);
            var jsonValue = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<Pagination<ProductType>>(jsonValue);

            singleResponse.Count.Should().Be(0);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(1)]
        public async Task GetByIdAsync_ShouldReturnBadRequest()
        {
            // Arrange
            var request = "/api/producttypes/1";

            // Act
            var response = await Client.GetAsync(request);


            response.StatusCode.Should().Be(404); 
        }

        [Fact, Priority(2)]
        public async Task Post_ShouldReturnOK()
        {
            // Arrange
            var request = "/api/producttypes";

            ProductType productType = new ProductType() { Id = "1", Name = "type1" };
            // Act
            var response = await Client.PostAsync(request , ContentHelper.GetStringContent(productType));

            // Assert
            response.StatusCode.Should().Be(200);
        }

        [Fact, Priority(3)]
        public async Task GetByIdAsync_ShouldReturnProductType()
        {
            // Arrange
            var request = "/api/producttypes/1";

            // Act
            var response = await Client.GetAsync(request);


            response.StatusCode.Should().Be(200);
            var jsonValue = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<ProductType>(jsonValue);

            singleResponse.Id.Should().Be("1");

        }
    }
}
