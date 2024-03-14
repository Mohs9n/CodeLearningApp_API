using codegym_api.Data;
using codegym_api.Interfaces;
using codegym_api.Services;
using Microsoft.EntityFrameworkCore;

namespace codegym_api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices
    (this IServiceCollection services, IConfiguration config)
    {

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite("Data source=codegym.db");
        });
        services.AddAuthorization();
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        // services.AddScoped<IPhotoService, PhotoService>();
        // services.AddScoped<LogUserActivity>();
        // services.AddSignalR();
        // services.AddSingleton<PresenceTracker>();
        // services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
