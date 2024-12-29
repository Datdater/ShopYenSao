using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Persistence.DatabaseContext;
using ShopYenSao.Persistence.Repositories;

namespace ShopYenSao.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<YenSaoDatabaseContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("ShopYenSao"));
        });
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        return services;
    }
}