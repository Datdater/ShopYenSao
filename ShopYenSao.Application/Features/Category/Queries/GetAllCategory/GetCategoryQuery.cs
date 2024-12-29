using MediatR;
using ShopYenSao.Application.Features.Category.Commands.GetAllCategory;

namespace ShopYenSao.Application.Features.Category.Queries.GetAllCategory;

public class GetCategoryQuery :IRequest<List<CategoryDto>>
{
}
