# Build the image using the .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Automated_Deployment/Automated_Deployment.csproj", "Automated_Deployment/"]
RUN dotnet restore "Automated_Deployment/Automated_Deployment.csproj"

# Copy the rest of the source code and build the application
COPY . .
WORKDIR "/src/Automated_Deployment"
RUN dotnet build "Automated_Deployment.csproj" -c Release -o /app/build

# Publish the application to a folder
FROM build AS publish
RUN dotnet publish "Automated_Deployment.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Create the final image using the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Automated_Deployment.dll"]