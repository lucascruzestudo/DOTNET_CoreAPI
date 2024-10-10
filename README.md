## Getting Started

Para uso do template é preciso ter a seguinte SDK:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (latest version)


## Tecnologias

* [ASP.NET Core 8](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 8](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [FluentAssertions](https://fluentassertions.com/), [Moq](https://github.com/moq) & [Respawn](https://github.com/jbogard/Respawn)
<!-- * [Angular 15](https://angular.io/) or [React 18](https://react.dev/) !-->
## Migrations

* **Adicionando:** dotnet ef migrations add Initial_Migration -p Infrastructure/ -s WebApi/ --output-dir Data/Migrations

* **Removendo:** dotnet ef migrations remove -p Infrastructure/ -s WebApi/

 
