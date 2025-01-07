using MediatR;
using ShopYenSao.Domain.Enums;

namespace ShopYenSao.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public OrderStatus OrderStatus { get; set; }

}