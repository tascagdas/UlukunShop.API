using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UlukunShopAPI.Application.Repositories;


namespace UlukunShopAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRespository _productReadRespository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRespository productReadRespository, IProductWriteRepository productWriteRepository)
        {
            _productReadRespository = productReadRespository;
            _productWriteRepository = productWriteRepository;
        }
        
        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(), Name = "Deneme1",Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10},
                new(){Id = Guid.NewGuid(), Name = "Deneme2",Price = 200, CreatedDate = DateTime.UtcNow, Stock = 42},
                new(){Id = Guid.NewGuid(), Name = "Deneme3",Price = 300, CreatedDate = DateTime.UtcNow, Stock = 64},
                new(){Id = Guid.NewGuid(), Name = "Deneme4",Price = 499, CreatedDate = DateTime.UtcNow, Stock = 14}
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
