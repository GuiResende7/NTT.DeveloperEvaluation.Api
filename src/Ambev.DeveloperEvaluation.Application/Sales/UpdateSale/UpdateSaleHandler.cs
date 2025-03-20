using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests
/// </summary>
public class UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="command">The UpdateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (sale is null)
        {
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");
        }

        if (!string.IsNullOrEmpty(command.Customer))
        {
            sale.Customer = command.Customer;
        }

        if (!string.IsNullOrEmpty(command.Branch))
        {
            sale.Branch = command.Branch;
        }

        var result = await _saleRepository.UpdateAsync(sale, cancellationToken);
        return _mapper.Map<UpdateSaleResult>(result);
    }
}
