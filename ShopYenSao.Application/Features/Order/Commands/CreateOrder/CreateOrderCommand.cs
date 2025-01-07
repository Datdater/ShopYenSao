using MediatR;
using ShopYenSao.Domain;
using ShopYenSao.Domain.Enums;

namespace ShopYenSao.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public List<CreateOrderDetail> OrderDetails { get; set; }
    public required string Address { get; set; }
    public Guid PromotionId { get; set; }
}