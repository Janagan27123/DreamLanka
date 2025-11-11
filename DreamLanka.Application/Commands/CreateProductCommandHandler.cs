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
        // Use AutoMapper instead of manual mapping
        var product = _mapper.Map<Domain.Entities.Product>(request.CreateProductDto);
        product.VendorId = request.VendorId;
        product.IsActive = true;

        var createdProduct = await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(createdProduct);
    }
}