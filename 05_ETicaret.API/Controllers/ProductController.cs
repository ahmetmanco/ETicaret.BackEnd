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
            var products = await _productReadRepository.GetAll().ToListAsync();
            var result = products.Select(x => new
            {
                image = x.ProductImage,
                x.Name,
                x.Id,
                x.Price,
                x.Stock,
                x.CreatedDate,
                x.UpdateDate
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductCreateVM product)
        {
            string? imagePath = null;

            if (product.Image != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(product.Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.Image.CopyToAsync(stream);
                }

                imagePath = $"https://localhost:7275/uploads/{uniqueFileName}";
            }

            await _productWriteRepository.AddAsync(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ProductImage = imagePath ,
               
            });

            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] ProductUpdateVM product)
        {
            Product product1 = await _productReadRepository.GetByIdAsync(product.Id);
            product1.Stock = product.Stock;
            product1.Price = product.Price;
            product1.Name = product.Name;

            if (product.Image != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(product.Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.Image.CopyToAsync(stream);
                }

                product1.ProductImage = $"/uploads/{uniqueFileName}";
            }

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
