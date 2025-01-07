using AutoMapper;
using MediatR;
using ShopYenSao.Application.Commons;
using ShopYenSao.Application.Contracts.Persistence;

namespace ShopYenSao.Application.Features.Order.Queries.GetAll;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Pagination<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<Pagination<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetPaginationAsync("OrderDetails", request.PageIndex, request.PageSize);
        var orderDtos = _mapper.Map<Pagination<OrderDto>>(orders);
        return orderDtos;
    }
}