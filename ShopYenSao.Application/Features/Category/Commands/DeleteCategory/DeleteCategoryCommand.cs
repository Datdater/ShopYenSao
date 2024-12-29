using MediatR;

namespace ShopYenSao.Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}