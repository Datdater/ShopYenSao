using ShopYenSao.Application.Features.Category.Commands.CreateCategory;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<bool> IsCategoryUnique(string categoryName);
}