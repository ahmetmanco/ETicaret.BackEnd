using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence.Context;

namespace _04_ETicaret.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<_01_ETicaret.Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
