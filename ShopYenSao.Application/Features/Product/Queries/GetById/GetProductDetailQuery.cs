using MediatR;

namespace ShopYenSao.Application.Features.Product.Queries.GetById;

public class GetProductDetailQuery : IRequest<ProductDetailDto>
{
    public Guid Id { get; set; }
}