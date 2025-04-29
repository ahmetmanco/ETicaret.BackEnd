using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_ETicaret.Domain.Base;
using _02_ETicaret.Application.Repositories;
using _04_ETicaret.Persistence_.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _04_ETicaret.Persistence_.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public WriteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<T> Table => _appDbContext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entry = await Table.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Delete(T entity)
        {
            EntityEntry entry = Table.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public bool DeleteRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<int> SaveAsync() => await _appDbContext.SaveChangesAsync();

        public bool UpdateAsync(T entity)
        {
            EntityEntry entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}
