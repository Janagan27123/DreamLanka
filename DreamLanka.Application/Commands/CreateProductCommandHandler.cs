using AutoMapper;
using DreamLanka.Application.DTOs;
using DreamLanka.Domain.Entities;
using DreamLanka.Domain.Interfaces;
using MediatR;

namespace DreamLanka.Application.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            VendorId = request.VendorId,
            Name = request.CreateProductDto.Name,
            Description = request.CreateProductDto.Description,
            Price = request.CreateProductDto.Price,
            StockQuantity = request.CreateProductDto.StockQuantity,
            Unit = request.CreateProductDto.Unit,
            Category = request.CreateProductDto.Category,
            ImageUrl = request.CreateProductDto.ImageUrl,
            DiscountPercentage = request.CreateProductDto.DiscountPercentage,
            DiscountValidUntil = request.CreateProductDto.DiscountValidUntil,
            IsActive = true
        };

        var createdProduct = await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(createdProduct);
    }
}