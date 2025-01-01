using AutoMapper;
using MediatR;
using ShopYenSao.Application.Commons;
using ShopYenSao.Application.Contracts.Persistence;

namespace ShopYenSao.Application.Features.Product.Queries.GetAll;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Pagination<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }
    
    public async Task<Pagination<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ProductRepository.GetPaginationAsync(nameof(Domain.Category), request.PageIndex, request.PageSize);
        var data = _mapper.Map<Pagination<ProductDto>>(result);
        return data;
    }
}