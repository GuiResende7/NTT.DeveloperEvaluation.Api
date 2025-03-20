using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Validator for CancelSaleItemRequest that defines validation rules for sale item cancelation.
/// </summary>
public class CancelSaleItemRequestValidator : AbstractValidator<CancelSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the CancelSaleItemRequestValidator with defined validation rules.
    /// </summary>
    public CancelSaleItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}