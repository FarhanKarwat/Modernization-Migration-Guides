# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ModernizedApi/ ModernizedApi/
RUN dotnet restore ModernizedApi/ModernizedApi.csproj
RUN dotnet publish ModernizedApi/ModernizedApi.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5178
ENV DOTNET_URLS=http://+:5178
ENTRYPOINT ["dotnet", "ModernizedApi.dll"]
