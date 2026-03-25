using Automated_Deployment.Controllers;
using Automated_Deployment.Entities;
using Automated_Deployment.Interfaces;
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
    public void GetAll_ReturnsOkResult_WithListOfProducts()
    {
        // Add List of Products to return from the mock service
        var mockService = new Mock<IProductService>();
        mockService.Setup(s => s.GetAll()).Returns(
        [
            new Product { Id = 1, Name = "Laptop" },
            new Product { Id = 2, Name = "Phone" }
        ]);

        var controller = new ProductsController(mockService.Object);

        // Act - Call the GetAll method
        var result = controller.GetAll();

        // Assert - Check if the result is OkObjectResult and contains the expected list of products
        var okResult = Assert.IsType<OkObjectResult>(result);
        var products = Assert.IsType<List<Product>>(okResult.Value);
        Assert.Equal(2, products.Count);
    }
}