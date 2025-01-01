using AutoMapper;
using ShopYenSao.Application.Commons;
using ShopYenSao.Application.Features.Product.Commands.CreateProduct;
using ShopYenSao.Application.Features.Product.Queries.GetAll;
using ShopYenSao.Domain;

namespace ShopYenSao.Application.MappingProfile;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProductCommands>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap(typeof(Pagination<>), typeof(Pagination<>));
    }
}