using System.Net;
using _01_ETicaret.Domain.Entities;
using _01_ETicaret.Domain_.Entities;
using _02_ETicaret.Application.Repositories;
using _02_ETicaret.Application.VMs.Product;
using _02_ETicaret.Application_.Abstractions.Storage;
using _02_ETicaret.Application_.Features.Queries.GetAllProduct;
using _02_ETicaret.Application_.RequestParameters;
using MediatR;
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
        private readonly IStorageService _storage;
        private readonly string _baseImageUrl = $"https://ticaret.blob.core.windows.net/files/";
        private readonly IMediator _mediator;


        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IStorageService storage, IMediator mediator)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _storage = storage;
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> Get(GetAllProductQueryRequest getAllProductQueryRequest) 
        {
            return Ok(await _mediator.Send(getAllProductQueryRequest));
            #region
            //////return Ok(_productReadRepository.GetAll());
            ////var products = await _productReadRepository.Table.Include(x => x.productImageFiles).ToListAsync();
            ////var result = products.Select(x => new
            ////{
            ////    //image = x.ProductImage.Select(x=> $"{_baseImageUrl}"),
            ////    image = x.productImageFiles?.Select(img => $"{_baseImageUrl}{img.FileName}").ToList() ?? new List<string>(),
            ////    x.Name,
            ////    x.Id,
            ////    x.Price,
            ////    x.Stock,
            ////    x.CreatedDate,
            ////    x.UpdateDate
            ////});
            ////return Ok(result);
            //var totalCount = _productReadRepository.GetAll(false).Count();
            //var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(x=> new
            //{
            //    x.Id,
            //    x.Name,
            //    x.Stock,
            //    x.Price,
            //    x.CreatedDate,
            //    x.UpdateDate,
            //}).ToList();

            //return Ok( new
            //{
            //    totalCount, products
            //});
            #endregion
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductCreateVM product)
        {
            var images = await _storage.UploadAsync("files", product.Image);
            await _productWriteRepository.AddAsync(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ProductImage = images.Select(x => x.pathOrContainerName).ToList()
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
                //product1.ProductImage = $"/uploads/{uniqueFileName}";
            }

            return Ok(await _productWriteRepository.SaveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            await _productWriteRepository.DeleteAsync(id);
            return Ok(await _productWriteRepository.SaveAsync());
        }
        //[HttpDelete("[action/{id}]")]
        //public async Task<IActionResult> DeleteProduct(int id, int imageId)
        //{
        //    Product? product = await _productReadRepository.Table.Include(x => x.productImageFiles).FirstOrDefaultAsync(x => x.Id == id);

        //    ProductImageFile productImage = product.productImageFiles.FirstOrDefault(x => x.Id == imageId);
        //    product.productImageFiles.Remove(productImage);
        //    await _productWriteRepository.SaveAsync();
        //    return Ok();
        //}
    }
}
