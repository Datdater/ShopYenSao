using FluentValidation;
using FluentValidation.Validators;
using ShopYenSao.Application.Contracts.Persistence;

namespace ShopYenSao.Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateCategoryCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.}")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
            .MinimumLength(2).WithMessage("{PropertyName} must at least 2 characters.");
            ;
            
        RuleFor(p => p)
            .MustAsync(CategoryUnique)
            .WithMessage("Category already exists.");
        _unitOfWork = unitOfWork;
    }

    private Task<bool> CategoryUnique(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return _unitOfWork.CategoryRepository.IsCategoryUnique(request.Name);
    }
}