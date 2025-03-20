using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Handler for processing CancelSaleCommand requests
/// </summary>
public class CancelSaleHandler(ISaleRepository saleRepository) : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
{
    private readonly ISaleRepository _saleRepository = saleRepository;

    /// <summary>
    /// Handles the CancelSaleCommand request
    /// </summary>
    /// <param name="request">The CancelSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the canceling operation</returns>
    public async Task<CancelSaleResponse> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleValidator();
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

        sale.Cancel();

        await _saleRepository.UpdateAsync(sale, cancellationToken);
        return new CancelSaleResponse { Success = true };
    }
}
