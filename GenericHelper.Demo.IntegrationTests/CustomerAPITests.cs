using FluentAssertions;
using GenericHelper.Demo.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace GenericHelper.Demo.IntegrationTests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class CustomerAPITests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;
        const string baseAddress = "/api/customer";
        static Customer responseCustomer;

        public CustomerAPITests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact, Priority(0)]
        public async Task Post_ShouldReturnPostEntity()
        {
            // Arrange
            Customer customer = new Customer() {Name = "Customer1" };
            // Act
            var response = await Client.PostAsync(baseAddress, ContentHelper.GetStringContent(customer));
            var jsonValue = await response.Content.ReadAsStringAsync();
            responseCustomer = JsonConvert.DeserializeObject<Customer>(jsonValue);

            // Assert
            responseCustomer.Name.Should().Be(customer.Name);
            responseCustomer.Id.Should().NotBeEmpty();
            response.StatusCode.Should().Be(200);
        }

        [Fact, Priority(1)]
        public async Task GetByIdAsync_ShouldReturnEntity()
        {
            // Arrange
            var request = $"{baseAddress}/{responseCustomer.Id}";

            // Act
            var response = await Client.GetAsync(request);

            var jsonValue = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<Customer>(jsonValue);

            response.StatusCode.Should().Be(200);
            singleResponse.Id.Should().Be(responseCustomer.Id);

        }
    }
}
