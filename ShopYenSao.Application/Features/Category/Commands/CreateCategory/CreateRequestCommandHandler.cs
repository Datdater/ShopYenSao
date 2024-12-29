using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;

namespace ShopYenSao.Application.Features.Category.Commands.CreateCategory;

public class CreateRequestCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryCommandValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(validationResult.ToString(), validationResult);
        }
        var category = _mapper.Map<Domain.Category>(request);
        await _unitOfWork.CategoryRepository.InsertAsync(category);
        await _unitOfWork.SaveAsync();
        return category.Id;
    }
}