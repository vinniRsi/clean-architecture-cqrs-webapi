using Domain.Enums;

namespace WebApi.Models;

public record UpdateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    ProductStatus Status
);
