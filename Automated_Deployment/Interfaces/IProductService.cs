using Automated_Deployment.Entities;

namespace Automated_Deployment.Interfaces;

public interface IProductService
{
    List<Product> GetAll();
}