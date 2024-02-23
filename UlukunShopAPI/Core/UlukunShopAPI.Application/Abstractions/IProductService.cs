using UlukunShopAPI.Domain.Entities;

namespace UlukunShopAPI.Application.Abstractions;

public interface IProductService
{
    List<Product> GetProducts();
}