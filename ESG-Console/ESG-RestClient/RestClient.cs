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

        public void SendCustomerDetails(CustomerDetailsDto details)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(15);
                StringContent content = new StringContent(JsonSerializer.Serialize(details), Encoding.UTF8, "application/json");

                string host = _configuration.GetSection("AppSettings:Api:Host").Value;

                if (host == null)
                {
                    Console.WriteLine("Host is null in the appsettings.json file, please set this");
                    return;
                }

                try
                {
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, Path.Combine(host, "api/customerdetails/addcustomers"))
                    {
                        Content = content
                    };

                    HttpResponseMessage response = client.Send(message);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Couldn't insert Customer :${details.CustomerRef}, {response.StatusCode}:{response.Content}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}