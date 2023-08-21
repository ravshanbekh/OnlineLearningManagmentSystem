using Domain.Commons;
using System.Linq.Expressions;

namespace Data.IRepositories;

public interface IRepository <T> where T : Auditable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetAsync(Expression<Func<T,bool>> expression, string[] includes = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNoTraced = true, string[] includes = null);
    Task SaveAsync();
}
