using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleByNumber;

/// <summary>
/// Validator for GetSaleByNumberRequest
/// </summary>
public class GetSaleByNumberRequestValidator : AbstractValidator<GetSaleByNumberRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSaleByNumberRequest
    /// </summary>
    public GetSaleByNumberRequestValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("The number is required");
    }
}
