using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence_.Context;

namespace _04_ETicaret.Persistence_.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<_01_ETicaret.Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
