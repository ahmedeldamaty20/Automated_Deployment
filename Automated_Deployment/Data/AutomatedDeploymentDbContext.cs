using Automated_Deployment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Automated_Deployment.Data;

public class AutomatedDeploymentDbContext(DbContextOptions<AutomatedDeploymentDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
