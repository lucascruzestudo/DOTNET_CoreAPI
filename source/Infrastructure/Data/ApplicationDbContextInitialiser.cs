using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Project.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static void InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        initialiser.InitialiseAsync();

        initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{

    public ApplicationDbContextInitialiser()
    {
    }

    public void InitialiseAsync()
    {
    }

    public void SeedAsync()
    {
    }
}
