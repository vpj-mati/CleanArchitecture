using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;
using ProcesoAutonomo.ServiceA.Infrastructure.Files;
using ProcesoAutonomo.ServiceA.Infrastructure.Persistence;
using ProcesoAutonomo.ServiceA.Infrastructure.Persistence.Interceptors;
using ProcesoAutonomo.ServiceA.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProcesoAutonomo.ServiceA.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ServiceADb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        var sett = configuration.GetSection(nameof(IdentityAuthenticationOptions)).Get<IdentityAuthenticationOptions>();
        services.AddAuthentication(sett?.DefaultScheme??"")
                .AddIdentityServerAuthentication(sett?.DefaultScheme, options =>
                {
                    options.RequireHttpsMetadata = sett?.RequireHttpsMetadata??false;
                    options.ApiName = sett?.ApiName;
                    options.Authority = sett?.Authority;
                });

        return services;
    }
}
