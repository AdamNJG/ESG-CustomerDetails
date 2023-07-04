using ESG_Console_Parser.Customer;
using ESG_Console_Parser.Ports;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace ESG_RestClient
{
    public class RestClient : ICustomerSender
    {
        private readonly IConfiguration _configuration;

        public RestClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendCustomerDetails(CustomerDetailsDto details)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonSerializer.Serialize(details), Encoding.UTF8, "application/json");

                string host = _configuration.GetSection("AppSettings:Api:Host").Value;

                if (host == null)
                {
                    Console.WriteLine("Host is null in the appsettings.json file, please set this");
                    return;
                }

                HttpResponseMessage response = await client.PostAsync(Path.Combine(host, "api/customerdetails/addcustomers"), content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                }
            }
        }
    }
}