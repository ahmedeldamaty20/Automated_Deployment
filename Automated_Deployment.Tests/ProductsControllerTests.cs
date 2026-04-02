using Automated_Deployment.Controllers;
using Automated_Deployment.Entities;
using Automated_Deployment.Interfaces;
using Automated_Deployment.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Deployment.Tests;

public class ProductsControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfProducts()
    {
        // Add List of Products to return from the mock service
        var mockService = new Mock<IProductService>();
        mockService.Setup(s => s.GetAll()).ReturnsAsync(new List<ProductDto>
        {
            new ProductDto { Name = "Laptop" },
            new ProductDto { Name = "Phone" }
        });

        var controller = new ProductsController(mockService.Object);

        // Act - Call the GetAll method
        var result = await controller.GetAll();

        // Assert - Check if the result is OkObjectResult and contains the expected list of products
        var okResult = Assert.IsType<OkObjectResult>(result);
        var products = Assert.IsType<List<ProductDto>>(okResult.Value);
        Assert.Equal(3, products.Count);
    }
}