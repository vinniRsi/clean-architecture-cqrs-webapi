using Domain.Enums;

namespace Application.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    ProductStatus Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
