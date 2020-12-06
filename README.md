# ASPNet Core API 
![BuildImage](https://github.com/phuocquach/mine-shop-service/workflows/.github/workflows/build_image.yml/badge.svg)

# Run database container
docker-compose -f ./docker-compose-soft.yml up

# Database update
dotnet ef migrations add InitilaPgDB --project src/Mine.Commerce.Api #add migration

dotnet ef database update --project src/Mine.Commerce.Api

# Dotnet test
dotnet test /p:CollectCoverage=true


# Url to access
Swagger API: http://localhost:3037/swagger/index.html
Grpc: http://localhost:3031', http://localhost:5051
API: http://localhost:3037/
