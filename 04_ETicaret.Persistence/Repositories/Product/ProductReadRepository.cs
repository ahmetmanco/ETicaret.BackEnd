using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence_.Context;

namespace _04_ETicaret.Persistence_.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<_01_ETicaret.Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
