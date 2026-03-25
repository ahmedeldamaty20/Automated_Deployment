namespace Automated_Deployment.Configurations;

public class DatabaseConnections
{
    public string DefaultConnection { get; set; } = null!;
    public string IntegrationTestsConnection { get; set; } = null!;
}
