using AutoMapper;
using MediatR;
using ShopYenSao.Application.Contracts.Persistence;

namespace ShopYenSao.Application.Features.Payment.Queries.GetById;

public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPaymentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<PaymentDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(request.Id);
        return _mapper.Map<PaymentDto>(payment);
    }
}