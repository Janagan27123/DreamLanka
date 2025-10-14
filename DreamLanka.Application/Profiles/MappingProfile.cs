using AutoMapper;
using DreamLanka.Application.DTOs;
using DreamLanka.Domain.Entities;

namespace DreamLanka.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User mappings
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        // Product mappings
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => 0.0))
            .ForMember(dest => dest.TotalReviews, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        // Order mappings
        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        // Vendor mappings
        CreateMap<Vendor, VendorDto>();
        CreateMap<CreateVendorDto, Vendor>()
            .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => 0.0))
            .ForMember(dest => dest.TotalReviews, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        // DeliveryPartner mappings
        CreateMap<DeliveryPartner, DeliveryPartnerDto>();
        CreateMap<CreateDeliveryPartnerDto, DeliveryPartner>()
            .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => 0.0))
            .ForMember(dest => dest.TotalDeliveries, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.TotalEarnings, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
