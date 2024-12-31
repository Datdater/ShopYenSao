using System.Linq.Expressions;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(object id);
    Task<List<T>> GetAllAsync(string? includeProperties = null);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includeProperties);
    Task<T> InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null);
}