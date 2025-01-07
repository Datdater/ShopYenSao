using MediatR;
using ShopYenSao.Domain.Enums;

namespace ShopYenSao.Application.Features.Payment.Queries.GetById;

public class GetPaymentByIdQuery : IRequest<PaymentDto>
{
    public Guid Id { get; set; }
}