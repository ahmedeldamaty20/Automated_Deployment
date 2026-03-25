using Automated_Deployment.Data;
using Automated_Deployment.Entities;
using Automated_Deployment.Interfaces;

namespace Automated_Deployment.Services;

public class ProductService(AutomatedDeploymentDbContext dbContext) : IProductService
{
    public List<Product> GetAll()
    {
        return dbContext.Products.ToList();
    }
}
