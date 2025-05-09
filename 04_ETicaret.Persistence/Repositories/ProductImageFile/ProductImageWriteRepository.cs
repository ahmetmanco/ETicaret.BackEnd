using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application_.Repositories.File;
using _02_ETicaret.Application_.Repositories.ProductImageFile;
using _04_ETicaret.Persistence_.Context;

namespace _04_ETicaret.Persistence_.Repositories.ProductImageFile
{
    public class ProductImageWriteRepository : WriteRepository<_01_ETicaret.Domain_.Entities.ProductImageFile>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
