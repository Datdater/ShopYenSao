using Microsoft.EntityFrameworkCore;
using ShopYenSao.Domain.Enums;

namespace ShopYenSao.Domain;

public class Order : BaseEntity
{
    public Account User { get; set; }
    public Guid UserId { get; set; }
    [Precision(18, 2)]
    public decimal OrderTotal { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } 
    public Guid? PromotionId { get; set; }
    public Promotion? Promotion { get; set; }
    
}