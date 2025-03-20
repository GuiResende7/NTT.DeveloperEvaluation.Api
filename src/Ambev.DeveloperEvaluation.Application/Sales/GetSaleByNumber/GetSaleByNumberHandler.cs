using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleByNumber;

/// <summary>
/// Handler for processing GetSaleByNumberCommand requests
/// </summary>
public class GetSaleByNumberHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<GetSaleByNumberCommand, GetSaleByNumberResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Handles the GetSaleByNumberCommand request
    /// </summary>
    /// <param name="request">The GetSaleByNumber command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<GetSaleByNumberResult> Handle(GetSaleByNumberCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleByNumberValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var result = await _saleRepository.GetByNumberAsync(request.Number, cancellationToken);
        if (result is null)
        {
            throw new KeyNotFoundException($"Sale with number {request.Number} not found");
        }

        return _mapper.Map<GetSaleByNumberResult>(result);
    }
}
