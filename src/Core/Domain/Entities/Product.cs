using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public ProductStatus Status { get; private set; }

    private Product() { }

    public static Product Create(string name, string description, decimal price, int stockQuantity)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "Price must be non-negative.");
        if (stockQuantity < 0) throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Stock quantity must be non-negative.");

        return new Product
        {
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = stockQuantity,
            Status = ProductStatus.Active
        };
    }

    public void Update(string name, string description, decimal price, int stockQuantity, ProductStatus status)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "Price must be non-negative.");
        if (stockQuantity < 0) throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Stock quantity must be non-negative.");

        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        Status = status;
        SetUpdatedAt();
    }
}
