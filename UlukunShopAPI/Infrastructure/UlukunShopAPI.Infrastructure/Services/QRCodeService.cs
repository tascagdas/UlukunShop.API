using QRCoder;
using UlukunShopAPI.Application.Abstractions.Services;

namespace UlukunShopAPI.Infrastructure.Services;

public class QRCodeService:IQRCodeService
{



    public byte[] GenerateQRCode(string text)
    {
        QRCodeGenerator generator = new ();
        QRCodeData data = generator.CreateQrCode(text,QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qrCode = new PngByteQRCode(data);
        byte[] bytes= qrCode.GetGraphic(10, new byte[]{84,90,77},new byte[]{240,240,240});
        return bytes;
    }
}