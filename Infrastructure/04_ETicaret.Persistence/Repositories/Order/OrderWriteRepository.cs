using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence.Context;

namespace _04_ETicaret.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<_01_ETicaret.Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
