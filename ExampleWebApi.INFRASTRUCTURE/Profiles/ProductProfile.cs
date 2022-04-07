using AutoMapper;
using ExampleWebApi.CORE.Models;
using ExampleWebApi.INFRASTRUCTURE.Entities;

namespace ExampleWebApi.INFRASTRUCTURE.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();
        }
    }
}
