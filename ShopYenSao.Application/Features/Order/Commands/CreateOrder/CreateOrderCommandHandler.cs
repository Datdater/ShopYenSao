using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }
    
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.AccountRepository.GetFirstOrDefaultAsync(u=> u.Id == request.UserId);
        if (user == null)
            throw new NotFoundException(nameof(Account), request.UserId);
        decimal totalAmount = 0;
        var orderDetails = new List<CreateOrderDetail>();
        foreach (var item in request.OrderDetails)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
            if (product == null)
                throw new NotFoundException(nameof(Domain.Product), item.ProductId);

            if (product.Quantity < item.Quantity)
                throw new BadRequestException($"Insufficient stock for product {item.ProductId}");

            // Update stock
            product.Quantity -= item.Quantity;
            await _unitOfWork.ProductRepository.UpdateAsync(product);

            // Create order detail
            var orderDetail = new CreateOrderDetail
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Total = product.Price * item.Quantity
            };
            orderDetails.Add(orderDetail);
            totalAmount += orderDetail.Total;
        }

        // Create order
        var orderDetailListForInsert = _mapper.Map<List<Domain.OrderDetail>>(orderDetails);
        var order = new Domain.Order
        {
            UserId = request.UserId,
            OrderTotal = totalAmount,
            OrderDetails = orderDetailListForInsert,
            Address = request.Address
        };
        await _unitOfWork.OrderRepository.InsertAsync(order);
        await _unitOfWork.SaveAsync();
        
        var orderDetailsInsert = new List<Domain.OrderDetail>();
        
        // Now create order details with the new OrderId
        foreach (var item in request.OrderDetails)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
            var orderDetail = new Domain.OrderDetail
            {
                OrderId = order.Id, // Now we have the OrderId
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Total = product.Price * item.Quantity
            };
            orderDetailsInsert.Add(orderDetail);
        }
        await _unitOfWork.OrderDetailRepository.AddRangeAsync(orderDetailsInsert);
        await _unitOfWork.SaveAsync();
        
        return order.Id;
    }
}