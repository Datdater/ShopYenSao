using AutoMapper;
using ShopYenSao.Application.Features.Payment.Commands.CreatePayment;
using ShopYenSao.Application.Features.Payment.Queries.GetById;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.MappingProfile;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Domain.Payment, CreatePaymentCommand>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
    }
}