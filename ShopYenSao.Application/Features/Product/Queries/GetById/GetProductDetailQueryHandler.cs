using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;

namespace ShopYenSao.Application.Features.Product.Queries.GetById;

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }
    
    public async Task<ProductDetailDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
    {
        var productDetails = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        if (productDetails == null)
        {
            throw new NotFoundException(nameof(Domain.Category), request.Id);
        }
        var data = _mapper.Map<ProductDetailDto>(productDetails);
        return data;
    }
}