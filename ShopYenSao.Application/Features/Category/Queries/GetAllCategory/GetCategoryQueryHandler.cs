using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Features.Category.Queries.GetAllCategory;

namespace ShopYenSao.Application.Features.Category.Commands.GetAllCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categoryDetails = await _unitOfWork.CategoryRepository.GetAllAsync();
        var data = _mapper.Map<List<CategoryDto>>(categoryDetails);
        return data;
    }
    
    
}