using MediatR;
using ShopYenSao.Application.Commons;

namespace ShopYenSao.Application.Features.Product.Queries.GetAll;

public class GetProductQuery : IRequest<Pagination<ProductDto>>
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}