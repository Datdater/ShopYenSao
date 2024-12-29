using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;

namespace ShopYenSao.Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _unitOfWork.CategoryRepository.GetFirstOrDefaultAsync(u => u.Id == request.Id);
        if (categoryToDelete == null)
        {
            throw new NotFoundException(nameof(Domain.Category), request.Id);
        }
        await _unitOfWork.CategoryRepository.DeleteAsync(categoryToDelete);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}