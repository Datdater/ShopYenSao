using MediatR;

namespace ShopYenSao.Application.Features.Payment.Commands.UpdatePayment;

public class UpdatePaymentCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public bool IsPaid { get; set; }
}