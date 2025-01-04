using ShopYenSao.Domain;

namespace ShopYenSao.Application.Features.Order.Queries.GetAll;

public class OrderDto
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public List<Guid> OrderDetails { get; set; }
    public Guid PromotionId { get; set; }
    public decimal OrderTotal { get; set; }

}