using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence.Context;

namespace _04_ETicaret.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<_01_ETicaret.Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
