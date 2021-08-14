using GenericHelper.Core.Errors;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GenericHelper.Demo.IntegrationTests
{
   
    
   public static class HttpClientExtension
    {
        //public static async Task<ApiResponse<T>> PostAsync<T>(this HttpClient Client, T obj)
        //{
        //    var response = await Client.PostAsync(baseAddress, ContentHelper.GetStringContent(obj));
        //    var jsonValue = await response.Content.ReadAsStringAsync();
        //    responseCustomer = JsonConvert.DeserializeObject<Customer>(jsonValue);

        //    // Assert
        //    responseCustomer.Name.Should().Be(customer.Name);
        //    responseCustomer.Id.Should().NotBeEmpty();
        //    response.StatusCode.Should().Be(200);
        //}
    }
}
