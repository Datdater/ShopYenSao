using FluentValidation;
using ShopYenSao.Application.Contracts.Persistence;

namespace ShopYenSao.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommands>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.ProductName).MinimumLength(2)
            .WithMessage("Name must be between 2 and 20 characters.");
        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("CategoryId cannot be empty.");
    }
}