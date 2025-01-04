﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShopYenSao.Application.Commons;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Domain;
using ShopYenSao.Persistence.DatabaseContext;

namespace ShopYenSao.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly YenSaoDatabaseContext _context;
    internal DbSet<T> dbSet;

    public GenericRepository(YenSaoDatabaseContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }
    public Task<T> GetByIdAsync(object id)
    {
        return dbSet.FirstOrDefaultAsync(x => x.Id == (Guid)id);
    }
    //Use for navigation included
    public async Task<List<T>> GetAllAsync(string? includeProperties)
    {
        IQueryable<T> query = dbSet;
        if (includeProperties != null)
        {
            foreach (var item in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
        }
        return await query.ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includeProperties)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        if (includeProperties != null)
        {
            foreach (var item in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
        }
        return await query.ToListAsync();
    }

    public async Task<T> InsertAsync(T entity)
    {
        var entitySaved = await dbSet.AddAsync(entity);
        return entitySaved.Entity;
    }

    public Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public  Task DeleteAsync(T entity)
    {
         dbSet.Remove(entity);
         return Task.CompletedTask;
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(predicate);
        if (includeProperties != null)
        {
            foreach (var item in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
        }
        return await query.FirstOrDefaultAsync();
    }
    public async Task<Pagination<T>> GetPaginationAsync(string? includeProperties = null, int pageIndex = 0, int pageSize = 10)
    {
        IQueryable<T> query = dbSet;
        if (includeProperties != null)
        {
            foreach (var item in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
        }
        var itemCount = await query.CountAsync();
        var items = await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
        var result = new Pagination<T>()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalItemsCount = itemCount,
            Items = items,
        };

        return result;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
    }    
}