FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
WORKDIR /src/src
RUN dotnet restore "./Mine.Commere.Service.sln"

#COPY . .
#WORKDIR "/src/."
RUN dotnet build "./Mine.Commerce.Api/Mine.Commerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Mine.Commerce.Api/Mine.Commerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mine.Commerce.Api.dll"]