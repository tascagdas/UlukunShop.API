namespace UlukunShopAPI.Application.Abstractions.Services;

public interface IQRCodeService
{
    byte[] GenerateQRCode(string text);
}