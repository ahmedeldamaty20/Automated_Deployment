using Automated_Deployment.Entities;
using Automated_Deployment.Interfaces;
using Automated_Deployment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Deployment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await productService.GetAll();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductDto product)
    {
        await productService.Add(product);
        return Ok(product);
    }
}
