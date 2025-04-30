using System.Net;
using _01_ETicaret.Domain.Entities;
using _02_ETicaret.Application.Repositories;
using _02_ETicaret.Application.VMs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VMs.Product;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //return Ok(_productReadRepository.GetAll());
            var products = await _productReadRepository.GetAll(false).ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateVM product)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductUpdateVM product)
        {
            Product product1 = await _productReadRepository.GetByIdAsync(product.Id);
            product1.Stock = product.Stock;
            product1.Price = product.Price;
            product1.Name = product.Name;
 
            return Ok(await _productWriteRepository.SaveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            await _productWriteRepository.DeleteAsync(id);
            return Ok(await _productWriteRepository.SaveAsync());
        }
    }
}
