# Automated Deployment — .NET 8 Web API with CI/CD

A .NET 8 Web API project demonstrating a complete CI/CD pipeline using GitHub Actions, Docker, and Azure Container Apps with SQL Server integration.

---

## 🛠️ Tech Stack

- **.NET 8** — Web API
- **SQL Server** — Database with Entity Framework Core
- **Docker** — Containerization
- **GitHub Actions** — CI/CD Pipeline
- **Azure Container Apps** — Hosting
- **Azure SQL** — Production Database
- **xUnit + Moq** — Unit Testing
- **Respawn** — Integration Testing

---

## 🔄 CI/CD Pipeline

### Continuous Integration (CI)

Every push or pull request to `main` triggers the following:

1. **Build** — Restores dependencies and builds the project in Release mode
2. **Code Formatting** — Verifies code formatting with `dotnet format`
3. **Unit Tests** — Runs unit tests using xUnit and Moq
4. **Integration Tests** — Runs integration tests against a real SQL Server instance running in Docker
5. **Docker Build & Push** — Builds the Docker image and pushes it to GitHub Container Registry (ghcr.io)

### Continuous Deployment (CD)

After a successful CI run:

6. **Database Migrations** — Automatically applies EF Core migrations to Azure SQL
7. **Deploy** — Deploys the latest Docker image to Azure Container Apps

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (local or Docker)

### Run Locally

```bash
# Clone the repository
git clone https://github.com/ahmedeldamaty20/Automated_Deployment.git
cd Automated_Deployment

# Restore dependencies
dotnet restore

# Apply migrations
dotnet ef database update --project Automated_Deployment

# Run the API
dotnet run --project Automated_Deployment
```

The API will be available at `https://localhost:5001`

---

## 🧪 Running Tests

```bash
# Run all tests
dotnet test

# Run unit tests only
dotnet test Automated_Deployment.Tests

# Run integration tests only
dotnet test Automated_Deployment.IntegrationTests
```

> **Note:** Integration tests require a running SQL Server instance. Connection string is read from the `SQL_PASSWORD` environment variable.

---

## 🔐 GitHub Secrets Required

| Secret | Description |
|--------|-------------|
| `SQL_PASSWORD` | SQL Server password for integration tests |
| `AZURE_CREDENTIALS` | Azure Service Principal JSON for deployment |
| `AZURE_SQL_CONNECTION_STRING` | Azure SQL connection string for migrations |
| `GHCR_TOKEN` | GitHub Personal Access Token with `read:packages` scope |

---

## 📁 Project Structure

```
Automated_Deployment/
├── Automated_Deployment/           # Main API project
├── Automated_Deployment.Tests/     # Unit tests
├── Automated_Deployment.IntegrationTests/  # Integration tests
├── .github/
│   └── workflows/
│       └── ci.yml                  # CI/CD pipeline
└── Dockerfile                      # Docker image definition
```

---

## 🌐 Live Demo

The API is deployed on Azure Container Apps:

```
https://automated-deployment-app.blackplant-ed6d43a7.germanywestcentral.azurecontainerapps.io/swagger/index.html
```
