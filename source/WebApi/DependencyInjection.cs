using Project.Application.Common.Interfaces;
using Project.Infrastructure.Data;
using Project.WebApiApi.Services;
using Microsoft.AspNetCore.Mvc;
using Project.WebApi.Configurations;
using System.Globalization;
using Project.Domain.Notifications;
using Project.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Project.Domain.Constants;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddAuthorization();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings!.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                RoleClaimType = ClaimTypes.Role
            };
        });

        var cultureInfo = new CultureInfo("pt-BR");
        cultureInfo.NumberFormat.CurrencySymbol = "R$";

        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        services.AddScoped<IUser, CurrentUser>();

        services.AddNotifications();

        services.AddHttpContextAccessor();

        services.AddControllers();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddSwaggerConfiguration();

        return services;
    }
    private static IServiceCollection AddNotifications(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<DomainSuccessNotification>, DomainSuccessNotificationHandler>();

        return services;
    }
}
