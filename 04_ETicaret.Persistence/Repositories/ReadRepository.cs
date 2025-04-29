using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain.Base;
using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence_.Context;
using Microsoft.EntityFrameworkCore;

namespace _04_ETicaret.Persistence_.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query.AsNoTracking();

            return await Table.SingleOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.Where(predicate);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
