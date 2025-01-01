using MediatR;
using ShopYenSao.Application.Commons;
using ShopYenSao.Application.Features.Category.Commands.GetAllCategory;

namespace ShopYenSao.Application.Features.Category.Queries.GetAllCategory;

public class GetCategoryQuery :IRequest<Pagination<CategoryDto>>
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}
