# ASPNet Core API 
![BuildImage](https://github.com/phuocquach/mine-shop-service/workflows/.github/workflows/build_image.yml/badge.svg)

# Run database container
docker-compose -f ./docker-compose-soft.yml up

# Database update
dotnet ef migrations add InitilaPgDB --project src/Mine.Commerce.Api #add migration

dotnet ef database update --project src/Mine.Commerce.Api