using AutoMapper;
using ShopYenSao.Application.Features.Order.Queries.GetAll;
using ShopYenSao.Application.Features.Order.Queries.GetById;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.MappingProfile;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderSpecific>().ReverseMap();
    }
}