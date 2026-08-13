using Domain.Enums;
using MediatR;

namespace Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    ProductStatus Status
) : IRequest;
