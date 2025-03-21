using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler(ISaleRepository saleRepository, IProductRepository productRepository, IMapper mapper, IMediator mediator) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }


        command.SaleProducts = command.SaleProducts.GroupBy(p => p.ProductId).Select(g => new CreateSaleProductCommand { ProductId = g.Key, Quantity = g.Sum(p => p.Quantity) }).ToList();

        var products = await _productRepository.GetById(command.SaleProducts.Select(p => p.ProductId).ToList(), cancellationToken);
        if (products is null || !products.Any())
        {
            throw new InvalidOperationException("Any product was found");
        }

        var sale = _mapper.Map<Sale>(command);

        // Set the product on sale entity
        foreach (var saleProduct in sale.SaleProducts)
        {
            var product = products.FirstOrDefault(p => p.Id == saleProduct.ProductId);
            if (product is null)
            {
                throw new InvalidOperationException($"Product with Id {saleProduct.ProductId} was not found");
            }

            saleProduct.Product = product;
        }

        sale.ValidateProductLimits();

        // Calculate the total value of the sale and set it, before to apply valid discount
        sale.SetSaleValue();

        // Set the possible discount percentage to apply on sale
        int discountPercentage = sale.CalculateDiscountPercentage();
        sale.SetDiscount(discountPercentage);

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        await _mediator.Publish(new SaleCreatedEvent(createdSale), cancellationToken);
        return _mapper.Map<CreateSaleResult>(createdSale);
    }
}
