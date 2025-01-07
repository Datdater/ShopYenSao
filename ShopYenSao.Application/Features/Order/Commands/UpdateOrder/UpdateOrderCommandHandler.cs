using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;

namespace ShopYenSao.Application.Features.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetFirstOrDefaultAsync(u => u.Id == request.Id, "OrderDetails");
        if (order == null)
        {
            throw new NotFoundException(nameof(Order), request.Id);
        }
        order.OrderStatus = request.OrderStatus;
        await _unitOfWork.OrderRepository.UpdateAsync(order);
        await _unitOfWork.SaveAsync();
        return order.Id;
    }
}