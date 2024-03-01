using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UlukunShopAPI.Application.Repositories;
using UlukunShopAPI.Persistence.Contexts;
using UlukunShopAPI.Persistence.Repositories;

namespace UlukunShopAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<UlukunAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);
        services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
        services.AddSingleton<ICustomerWriteRepository,CustomerWriteRespository>();
        services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
        services.AddSingleton<IOrderWriteRepository,OrderWriteRepository>();
        services.AddSingleton<IProductReadRespository,ProductReadRepository>();
        services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();
    }
}