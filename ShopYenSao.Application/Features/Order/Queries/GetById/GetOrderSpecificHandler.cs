using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;

namespace ShopYenSao.Application.Features.Order.Queries.GetById;

public class GetOrderSpecificHandler : IRequestHandler<GetOrderSpecificQuery, OrderSpecific >
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetOrderSpecificHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<OrderSpecific> Handle(GetOrderSpecificQuery request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetFirstOrDefaultAsync(u => u.Id == request.Id, "OrderDetails");
        return _mapper.Map<OrderSpecific>(order);
    }
}