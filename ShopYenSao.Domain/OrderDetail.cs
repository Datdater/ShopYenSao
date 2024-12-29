using Microsoft.EntityFrameworkCore;

namespace ShopYenSao.Domain;

public class OrderDetail : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    [Precision(18, 2)]
    public decimal Total { get; set; }
}