using System.Linq.Expressions;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Domain;
using ShopYenSao.Persistence.DatabaseContext;

namespace ShopYenSao.Persistence.Repositories;

public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
{
    public SubCategoryRepository(YenSaoDatabaseContext context) : base(context)
    {
    }
}