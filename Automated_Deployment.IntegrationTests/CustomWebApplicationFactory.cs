using Automated_Deployment.Configurations;
using Automated_Deployment.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Deployment.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public string ConnectionString { get; } =
    $"Server=localhost,1433;Database=TestDb;User Id=sa;Password={Environment.GetEnvironmentVariable("SQL_PASSWORD")};TrustServerCertificate=True";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the existing DbContext registration
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AutomatedDeploymentDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            // Add a new DbContext registration with the test connection string
            services.AddDbContext<AutomatedDeploymentDbContext>(options =>
                options.UseSqlServer(ConnectionString));
        });
    }
}
