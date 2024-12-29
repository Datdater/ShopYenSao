using Microsoft.EntityFrameworkCore;

namespace ShopYenSao.Domain;

public class Payment
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public string Description { get; set; }
    [Precision(18, 2)]
    public decimal Amount { get; set; }
}