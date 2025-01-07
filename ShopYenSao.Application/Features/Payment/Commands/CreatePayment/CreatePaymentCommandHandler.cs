using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;
using ShopYenSao.Application.Exception;

namespace ShopYenSao.Application.Features.Payment.Commands.CreatePayment;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            throw new NotFoundException(nameof(Order), request.OrderId);
        }
        var payment = _mapper.Map<Domain.Payment>(request);
        payment.IsPaid = false;
        payment.Amount = order.OrderTotal;
        await _unitOfWork.PaymentRepository.InsertAsync(payment);
        await _unitOfWork.SaveAsync();
        return payment.Id;
    }
}