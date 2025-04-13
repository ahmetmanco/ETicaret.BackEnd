using _01_ETicaret.Domain.Base;

namespace _02_ETicaret.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool UpdateAsync(T entity);
        bool Delete(T entity);
        bool DeleteRange(List<T> entities);
        //bool Delete(int id);
        Task<int> SaveAsync();
    }
}
