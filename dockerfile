# Use official .NET image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShopYenSao.csproj", "./"]
RUN dotnet restore "./ShopYenSao.API.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet publish "./ShopYenSao.API.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ShopYenSao.API.dll"]
