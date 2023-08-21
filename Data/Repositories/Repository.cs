using Data.Contexts;
using Data.IRepositories;
using Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext dbContext;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.Now;
        await this.dbContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        this.dbContext.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null,bool isNoTraced = true, string[] includes=null)
    {
        IQueryable<T> query=expression is null? dbContext.Set<T>().AsQueryable(): dbContext.Set<T>().Where(expression).AsQueryable();
        
        query=isNoTraced ? query.AsNoTracking(): query;
        
        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes )
    {
        IQueryable<T> query = dbContext.Set<T>().Where(expression).AsQueryable();
        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        var entity=await query.FirstOrDefaultAsync(expression);
        
        return entity;
    }

    public async Task SaveAsync()
    {
        await this.dbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        dbContext.Entry(entity).State=EntityState.Modified;
    }
}
