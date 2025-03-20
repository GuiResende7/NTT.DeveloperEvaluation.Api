using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// Validator for CancelSaleRequest that defines validation rules for sale cancelation.
/// </summary>
public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CancelSaleRequestValidator with defined validation rules.
    /// </summary>
    public CancelSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}