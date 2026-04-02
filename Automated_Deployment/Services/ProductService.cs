using Automated_Deployment.Data;
using Automated_Deployment.Entities;
using Automated_Deployment.Interfaces;
using Automated_Deployment.Models;
using Microsoft.EntityFrameworkCore;

namespace Automated_Deployment.Services;

public class ProductService(AutomatedDeploymentDbContext dbContext) : IProductService
{
    public async Task Add(ProductDto product)
    {
        var productEntity = new Product
        {
            Name = product.Name
        };

        // Add the product to the database
        await dbContext.Products.AddAsync(productEntity);

        await dbContext.SaveChangesAsync();
    }

    public async Task<List<ProductDto>> GetAll()
    {
        var products = await dbContext.Products.ToListAsync();
        var productDtos = products.Select(p => new ProductDto
        {
            Name = p.Name
        }).ToList();
        return productDtos;
    }


}
