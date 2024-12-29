using MediatR;

namespace ShopYenSao.Application.Features.Category.Queries.GetCategoryDetails;

public record GetCategoryDetailsQuery(Guid Id) : IRequest<CategoryDetailDto>;