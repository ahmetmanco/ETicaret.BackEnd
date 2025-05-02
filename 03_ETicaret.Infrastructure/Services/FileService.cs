using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application_.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace _03_ETicaret.Infrastructure_.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string?> UploadAsync( IFormFile file)
        {
            if (file == null) return null;

            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if(!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            string filePath = Path.Combine(uploadPath, uniqueFileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"https://localhost:7275/uploads/{uniqueFileName}";
        }
    }
}
