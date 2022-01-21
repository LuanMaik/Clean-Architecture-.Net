# Clean Architecture - .Net Core 6

## Libs used
- [MediatR](https://www.nuget.org/packages/MediatR/)
- [FluentValidation](https://www.nuget.org/packages/FluentValidation)
- [Swashbuckle](https://www.nuget.org/packages/Swashbuckle.AspNetCore)

## Files location
- Web Controllers: /CleanArchitecture.WebAPI/Controllers
- Uses Cases: /CleanArchitecture.Application/UseCases
- Entity Models: /CleanArchitecture.Domain/Entities
- Repositories Implementation: /CleanArchitecture.Infrastructure.Data/EntityFrameworkCore/Repositories


## Layers
Each layer (project) has a _DependencyInjection.cs_ file, that contains a extension method to _IServiceCollection_, 
to defining the dependencies injection to this layer. These extensions are called in _Program.cs_ in root of WebAPI layer.

- WebAPI: Handle HTTP requests using controllers, and use MediatR to execute the use cases in Application layer.
- Application: It has the use cases with business logic to process commands and queries.
- Infrastructure.Data: It has the repositories implementations to read and write data in database.
- Domain: It has the entities definitions.

## MediatR
I created a Anti-Corruption Layer to using MediatR, so my Commands and Handlers don't use de MediatR directly.

