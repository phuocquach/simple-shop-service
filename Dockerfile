FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/src
RUN dotnet restore "./Mine.Commerce.Service.sln"

#COPY . .
#WORKDIR "/src/."
RUN dotnet build "./Mine.Commerce.Api/Mine.Commerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Mine.Commerce.Api/Mine.Commerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mine.Commerce.Api.dll"]
