using ESG_Rest_Server_Api.Controllers;
using ESG_Rest_Server_Application.CustomerDetails;
using ESG_Rest_Server_Application.CustomerDetails.interfaces;
using ESG_Rest_Server_Repository.Repositories;

namespace ESG_Rest_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddControllers()
                .AddApplicationPart(typeof(CustomerDetailsController).Assembly);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddLogging();
            builder.Services.AddSingleton<ICustomerDetailsStorage, CustomerDetailsRepository>();
            builder.Services.AddScoped<CustomerDetailsService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}