using System.Threading.Tasks;
using _01_ETicaret.Domain.Entities;
using _02_ETicaret.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05_ETicaret.API.Controllers
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
            await _productWriteRepository.AddAsync(new()
            {
                Id = 5,
                Name = "ahmet",
                Price = 234678,
                Stock = 34578,
            });
            await _productWriteRepository.SaveAsync();
            
        }
        //[HttpGet("id")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    Product product = await _productReadRepository.ge
        //}
    }
}
