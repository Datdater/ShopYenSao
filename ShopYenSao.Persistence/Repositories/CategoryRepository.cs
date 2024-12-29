using Microsoft.EntityFrameworkCore;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Domain;
using ShopYenSao.Persistence.DatabaseContext;

namespace ShopYenSao.Persistence.Repositories;

public class CategoryRepository :  GenericRepository<Category>, ICategoryRepository
{
    private readonly YenSaoDatabaseContext _context;
    public CategoryRepository(YenSaoDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsCategoryUnique(string categoryName)
    {
        return await _context.Categories.AnyAsync(u => u.Name == categoryName) == false;
    }
}