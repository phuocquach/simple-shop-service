# MS-Service (Mine.Shop.Service)
A small service for a small shop, using Asp.Net Core 3.x, which focusing on learning and practicing C#, .Net and the ecosystem on .Net.

## Status Check
![Build And Test](https://github.com/phuocquach/mine-shop-service/workflows/.github/workflows/build_image.yml/badge.svg)

## The technical stack:

* .NET Core 3.x
* Expose Rest and [grpc] (https://github.com/grpc/grpc-dotnet) API
* Using [RabbitMQ](https://www.rabbitmq.com/) as a message broker based on [Masstransit](http://masstransit-project.com/) (TODO)
* SQL database with [Postgresql](https://www.postgresql.org/)
* Data migration with [Dbup](https://github.com/DbUp/DbUp/) (Todo)
* Accessing database with [EF](https://docs.microsoft.com/en-us/ef/core/) (TODO:  [Dapper](https://github.com/StackExchange/Dapper))
* In-process messaging with [MediatR](https://github.com/jbogard/MediatR)
* Polly (TODO)
* Identity and access management with [Identity server 4](http://docs.identityserver.io/en/latest/#)
* Building [Docker](https://www.docker.com/) images
* [Docker compose](https://docs.docker.com/compose/)
* CI & CD with [Github action](https://github.com/features/actions)

## Set up local environment
### Run database container
docker-compose -f ./docker-compose-soft.yml up

### Database update
dotnet ef migrations add InitilaPgDB --project src/Mine.Commerce.Api #add migration
dotnet ef database update --project src/Mine.Commerce.Api

### Dotnet test
dotnet test /p:CollectCoverage=true
