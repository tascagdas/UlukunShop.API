using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UlukunShopAPI.Application.Abstractions;
using UlukunShopAPI.Persistence.Concretes;
using UlukunShopAPI.Persistence.Contexts;

namespace UlukunShopAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<UlukunAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
    }
}