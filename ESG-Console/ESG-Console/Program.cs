using ESG_Console.Process;
using ESG_Console_Parser.ParserServices;
using ESG_Console_Parser.Ports;
using ESG_RestClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESG_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            IServiceCollection services = new ServiceCollection();

            //services.AddTransient<CsvParserService>();
            services.AddTransient<Runner>();
            services.AddTransient<CsvParserService>();
            services.AddTransient<ICustomerSender, RestClient>();
            services.AddSingleton(config);

            // Build the service provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            // Resolve and run your console app's entry point
            Runner app = serviceProvider.GetRequiredService<Runner>();
            app.Run();
        }
    }

}