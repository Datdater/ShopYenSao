using ShopYenSao.Application.Features.OrderDetail.Queries.GetAll;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.Features.Order.Queries.GetById;

public class OrderSpecific
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }
    public Guid PromotionId { get; set; }
    public decimal OrderTotal { get; set; }
}