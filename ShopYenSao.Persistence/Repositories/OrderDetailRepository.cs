using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Domain;
using ShopYenSao.Persistence.DatabaseContext;

namespace ShopYenSao.Persistence.Repositories;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepostitory
{
    public OrderDetailRepository(YenSaoDatabaseContext context) : base(context)
    {
    }
}