using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence.Context;

namespace _04_ETicaret.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<_01_ETicaret.Domain.Entities.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
