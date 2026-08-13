using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
        => _repository = repository;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);

        product.Update(request.Name, request.Description, request.Price, request.StockQuantity, request.Status);
        _repository.Update(product);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}
