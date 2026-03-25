using Automated_Deployment.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Deployment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = productService.GetAll();
        return Ok(products);
    }
}
