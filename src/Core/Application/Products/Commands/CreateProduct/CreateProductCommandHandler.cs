using Application.Common.Interfaces;
using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
        => _repository = repository;

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name, request.Description, request.Price, request.StockQuantity);
        await _repository.AddAsync(product, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return new ProductDto(product.Id, product.Name, product.Description,
            product.Price, product.StockQuantity, product.Status, product.CreatedAt, product.UpdatedAt);
    }
}
