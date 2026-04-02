using Automated_Deployment.Entities;
using Automated_Deployment.Models;

namespace Automated_Deployment.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAll();
    Task Add(ProductDto product);
}