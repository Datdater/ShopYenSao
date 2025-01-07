using AutoMapper;
using ShopYenSao.Application.Features.Payment.Commands.CreatePayment;

namespace ShopYenSao.Application.MappingProfile;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Domain.Payment, CreatePaymentCommand>().ReverseMap();
    }
}