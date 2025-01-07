using MediatR;
using ShopYenSao.Domain.Enums;

namespace ShopYenSao.Application.Features.Payment.Commands.CreatePayment;

public class CreatePaymentCommand : IRequest<Guid>
{
    public Guid OrderId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string Description { get; set; }
    
}