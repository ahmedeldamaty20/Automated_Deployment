using Automated_Deployment.Data;
using Automated_Deployment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Deployment.IntegrationTests;

public class ProductsIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly AutomatedDeploymentDbContext _context;

    public ProductsIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();

        var scope = factory.Services.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<AutomatedDeploymentDbContext>();

        // Ensure the database is created and migrated before running tests
        _context.Database.Migrate();
    }

    [Fact]
    public async Task GetAll_ReturnsProducts_FromRealDatabase()
    {
        // Arrange - Add a product to the real database
        _context.Products.Add(new Product { Name = "Laptop" });
        await _context.SaveChangesAsync();

        // Act - Call the API endpoint to get all products
        var response = await _client.GetAsync("/api/products");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Laptop", content);
    }
}
