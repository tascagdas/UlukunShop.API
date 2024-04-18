using MediatR;
using UlukunShopAPI.Application.Abstractions.Services;

namespace UlukunShopAPI.Application.Features.Commands.Product.UpdateStockWithQrCode;

public class UpdateStockWithQrCodeCommandHandler:IRequestHandler<UpdateStockWithQrCodeCommandRequest,UpdateStockWithQrCodeCommandResponse>
{
    private readonly IProductService _productService;

    public UpdateStockWithQrCodeCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<UpdateStockWithQrCodeCommandResponse> Handle(UpdateStockWithQrCodeCommandRequest request, CancellationToken cancellationToken)
    {
        await _productService.UpdateStockAsync(request.ProductId, request.Stock);
        return new UpdateStockWithQrCodeCommandResponse();
    }
}