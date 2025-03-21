using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Handler for processing CancelSaleItemCommand requests
/// </summary>
public class CancelSaleItemHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator) : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Handles the CancelSaleItemCommand request
    /// </summary>
    /// <param name="request">The CancelSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the canceling item operation</returns>
    public async Task<CancelSaleItemResult> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale is null)
        {
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
        }

        if (sale.Canceled)
        {
            throw new InvalidOperationException($"Sale with ID {request.Id} is already canceled");
        }

        var saleProduct = sale.SaleProducts.FirstOrDefault(sp => sp.ProductId == request.ProductId);
        if (saleProduct is null)
        {
            throw new InvalidOperationException($"Product with ID {request.ProductId} not found in sale with ID {request.Id}");
        }

        saleProduct.CancelItem();

        // Set the possible discount percentage to apply on sale
        int discountPercentage = sale.CalculateDiscountPercentage();
        sale.SetDiscount(discountPercentage);

        // Calculate the total value of the sale and set it, before to apply valid discount
        sale.SetSaleValue();

        var result = await _saleRepository.UpdateAsync(sale, cancellationToken);
        await _mediator.Publish(new SaleProductCancelatedEvent(saleProduct), cancellationToken);
        return _mapper.Map<CancelSaleItemResult>(result);
    }
}
