﻿using Microsoft.EntityFrameworkCore;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Domain;
using ShopYenSao.Persistence.DatabaseContext;

namespace ShopYenSao.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly YenSaoDatabaseContext _context;
    private bool _disposed = false;
    public ICategoryRepository CategoryRepository { get; }
    public ISubCategoryRepository SubCategoryRepository { get; }

    public UnitOfWork(YenSaoDatabaseContext context)
    {
        _context = context;
        CategoryRepository = new CategoryRepository(_context);
        SubCategoryRepository = new SubCategoryRepository(_context);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
    public async Task<int> SaveAsync()
    {
        foreach (var entry in _context.ChangeTracker.Entries<BaseEntity>())
        {
            // switch (entry.State)
            // {
            //     case EntityState.Added:
            //         entry.Entity.Created = DateTime.Now;
            // }
        }
        return await _context.SaveChangesAsync();
    }
}