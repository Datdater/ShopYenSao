using MediatR;

namespace ShopYenSao.Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; }
}