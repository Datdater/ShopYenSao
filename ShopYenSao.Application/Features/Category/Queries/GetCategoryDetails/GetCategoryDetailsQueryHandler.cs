using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;

namespace ShopYenSao.Application.Features.Category.Queries.GetCategoryDetails;

public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryDetailsQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
    }

    public async Task<CategoryDetailDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var categoryDetails =await _unitOfWork.CategoryRepository.GetFirstOrDefaultAsync(u => u.Id == request.Id, "SubCategories");

        if (categoryDetails == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        var data = _mapper.Map<CategoryDetailDto>(categoryDetails);

        //return
        return data;                
    }
}