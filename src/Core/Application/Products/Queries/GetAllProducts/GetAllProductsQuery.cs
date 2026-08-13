using Application.DTOs;
using MediatR;

namespace Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;
