using Microsoft.EntityFrameworkCore;
using ShopYenSao.Domain.Enums;

namespace ShopYenSao.Domain;

public class Payment : BaseEntity
{
    public Guid OrderId { get; set; }
    public required Order Order { get; set; }
    public string Description { get; set; }
    [Precision(18, 2)]
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public bool IsPaid { get; set; }
}