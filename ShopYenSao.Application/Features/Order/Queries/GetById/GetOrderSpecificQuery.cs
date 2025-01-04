using MediatR;

namespace ShopYenSao.Application.Features.Order.Queries.GetById;

public class GetOrderSpecificQuery : IRequest<OrderSpecific>
{
    public Guid Id { get; set; }
}