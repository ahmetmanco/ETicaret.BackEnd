using System.Linq.Expressions;
using _01_ETicaret.Domain.Base;

namespace _02_ETicaret.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetByIdAsync(object id); // bunu entityRepositorylerinin içinde eklenebilir çünkü id baseEntity'den alınmıyor.
    }
}
