using _02_ETicaret.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05_ETicaret.API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){ CreatedDate = DateTime.Now, Id = 1, Name = "Test", Price = 234, Stock=487  },
                new(){ CreatedDate = DateTime.Now, Id = 2, Name = "Test1", Price = 2345, Stock=484  },
                new(){ CreatedDate = DateTime.Now, Id = 3, Name = "Test2", Price = 2344, Stock=481  },
                new(){ CreatedDate = DateTime.Now, Id = 4, Name = "Test3", Price = 2343, Stock=482  }
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
