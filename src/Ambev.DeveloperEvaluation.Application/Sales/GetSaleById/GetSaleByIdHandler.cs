using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
/// Handler for processing GetSaleByIdCommand requests
/// </summary>
public class GetSaleByIdHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<GetSaleByIdCommand, GetSaleByIdResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Handles the GetSaleByIdCommand request
    /// </summary>
    /// <param name="request">The GetSaleById command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<GetSaleByIdResult> Handle(GetSaleByIdCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleByIdValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var result = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
        {
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
        }

        return _mapper.Map<GetSaleByIdResult>(result);
    }
}
