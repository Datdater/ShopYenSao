using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;

namespace ShopYenSao.Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id);
        if (category == null)
        {
            throw new NotFoundException(nameof(Domain.Category), request.Id);
        }
        category.Name = request.Name;
        await _unitOfWork.CategoryRepository.UpdateAsync(category);
        await _unitOfWork.SaveAsync();
        return category.Id;
    }
}