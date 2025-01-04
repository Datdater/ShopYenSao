using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Domain;
using ShopYenSao.Persistence.DatabaseContext;

namespace ShopYenSao.Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(YenSaoDatabaseContext context) : base(context)
    {
    }
}