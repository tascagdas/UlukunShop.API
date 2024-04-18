namespace UlukunShopAPI.Application.Abstractions.Services;

public interface IProductService
{
    Task<byte[]> GenerateProductQrCodeAsync(string productId);
    Task UpdateStockAsync(string productId,int stock);
}