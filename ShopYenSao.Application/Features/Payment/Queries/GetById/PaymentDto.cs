using ShopYenSao.Domain.Enums;

namespace ShopYenSao.Application.Features.Payment.Queries.GetById;

public class PaymentDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public bool IsPaid { get; set; }
}