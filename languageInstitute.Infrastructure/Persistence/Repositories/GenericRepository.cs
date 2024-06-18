using languageInstitute.Domain.Contracts;
using languageInstitute.Domain.Entities;
using languageInstitute.Domain.ValueObjects;
using languageInstitute.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace languageInstitute.Infrastructure.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(TEntity entity, CancellationToken ct)
    {
        //First Way
        //_dbContext.Add(entity);

        //Second way
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(TEntity entity, CancellationToken ct)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken ct)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<IList<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
    {
        _dbContext.Set<Class>().Where(x => x.ClassName == "el1").FirstOrDefault();
        _dbContext.Set<Class>().Where(x => x.TeacherId == 15).FirstOrDefault();

        return await _dbContext.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
    }

    public Task<IEnumerable<TEntity>> FindByQueryCriteria(QueryCriteria queryCriteria)
    {
        throw new NotImplementedException();
    }

    Task<IList<TEntity>> IGenericRepository<TEntity>.GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    Task<IList<TEntity>> IGenericRepository<TEntity>.FindByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<TEntity>> IGenericRepository<TEntity>.FindByQueryCriteria(QueryCriteria queryCriteria)
    {
        throw new NotImplementedException();
    }

    Task<bool> IGenericRepository<TEntity>.AddAsync(TEntity entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    Task<bool> IGenericRepository<TEntity>.UpdateAsync(TEntity entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    Task<bool> IGenericRepository<TEntity>.DeleteAsync(TEntity entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
