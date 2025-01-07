using MediatR;
using ShopYenSao.Application.Commons;

namespace ShopYenSao.Application.Features.Order.Queries.GetAll;

public class GetOrderQuery : IRequest<Pagination<OrderDto>>
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}