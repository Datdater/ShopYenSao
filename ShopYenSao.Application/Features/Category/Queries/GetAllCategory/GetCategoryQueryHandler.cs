using AutoMapper;
using MediatR;
using ShopYenSao.Application.Commons;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Features.Category.Queries.GetAllCategory;

namespace ShopYenSao.Application.Features.Category.Commands.GetAllCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Pagination<CategoryDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Pagination<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categoryDetails = await _unitOfWork.CategoryRepository.GetPaginationAsync(null, request.PageIndex, request.PageSize);
        var data = _mapper.Map<Pagination<CategoryDto>>(categoryDetails);
        
        return data;
    }
    
    
}