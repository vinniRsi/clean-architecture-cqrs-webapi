using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.DTOs;
using MediatR;

namespace Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
        => _repository = repository;

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);

        return new ProductDto(product.Id, product.Name, product.Description,
            product.Price, product.StockQuantity, product.Status, product.CreatedAt, product.UpdatedAt);
    }
}
