using ShopYenSao.Application.Features.OrderDetail.Queries.GetAll;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.Features.Order.Queries.GetAll;

public class OrderDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PromotionId { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }

    public decimal OrderTotal { get; set; }

}