using EasyHR.DemoFormApp.Entities.Base;
using System.Linq.Expressions;

namespace EasyHR.DemoFormApp.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
