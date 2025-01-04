using AutoMapper;
using ShopYenSao.Application.Features.Order.Commands.CreateOrder;
using ShopYenSao.Application.Features.OrderDetail.Queries.GetAll;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.MappingProfile;

public class OrderDetailProfile : Profile
{
    public OrderDetailProfile()
    {
        CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, CreateOrderDetail>().ReverseMap();
        
    }
}