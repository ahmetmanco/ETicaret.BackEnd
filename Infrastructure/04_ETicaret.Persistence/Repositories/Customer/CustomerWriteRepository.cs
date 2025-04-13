using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence.Context;

namespace _04_ETicaret.Persistence.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<_01_ETicaret.Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
