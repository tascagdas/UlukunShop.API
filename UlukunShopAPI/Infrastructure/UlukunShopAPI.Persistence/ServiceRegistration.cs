using Microsoft.Extensions.DependencyInjection;
using UlukunShopAPI.Application.Abstractions;
using UlukunShopAPI.Persistence.Concretes;

namespace UlukunShopAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>();
    }
}