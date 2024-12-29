using MediatR;

namespace ShopYenSao.Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}