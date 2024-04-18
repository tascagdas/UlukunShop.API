using System.Text.Json;
using UlukunShopAPI.Application.Abstractions.Services;
using UlukunShopAPI.Application.Repositories;
using UlukunShopAPI.Domain.Entities;

namespace UlukunShopAPI.Persistence.Services;

public class ProductService:IProductService
{
    private readonly IProductReadRespository _productReadRespository;
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IQRCodeService _qrCode;

    public ProductService(IProductReadRespository productReadRespository, IQRCodeService qrCode, IProductWriteRepository productWriteRepository)
    {
        _productReadRespository = productReadRespository;
        _qrCode = qrCode;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<byte[]> GenerateProductQrCodeAsync(string productId)
    {
        Product product = await _productReadRespository.GetByIdAsync(productId);
        if (product==null)
        {
            throw new Exception("Product is not found");
        }

        var plainObject = new
        {
            product.Id,
            product.Name,
            product.Price,
            product.Stock,
            product.CreatedDate
        };
        string plainText = JsonSerializer.Serialize(plainObject);
        return _qrCode.GenerateQRCode(plainText);
    }

    public async Task UpdateStockAsync(string productId, int stock)
    {
        Product product = await _productReadRespository.GetByIdAsync(productId);
        if (product==null)
        {
            throw new Exception("Product is not found");
        }

        product.Stock = stock;
        await _productWriteRepository.SaveAsync();
    }
}