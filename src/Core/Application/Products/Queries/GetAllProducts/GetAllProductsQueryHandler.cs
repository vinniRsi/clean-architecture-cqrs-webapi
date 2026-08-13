using Application.Common.Interfaces;
using Application.DTOs;
using MediatR;

namespace Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
        => _repository = repository;

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products.Select(p => new ProductDto(
            p.Id, p.Name, p.Description, p.Price, p.StockQuantity, p.Status, p.CreatedAt, p.UpdatedAt));
    }
}
