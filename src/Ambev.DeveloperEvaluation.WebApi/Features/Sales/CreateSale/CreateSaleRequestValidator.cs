using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sales creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    public CreateSaleRequestValidator()
    {
        RuleFor(user => user.Customer)
            .NotEmpty().WithMessage("Customer name must be provided.")
            .MinimumLength(3).WithMessage("Customer name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Customer name cannot be longer than 50 characters.");

        RuleFor(sale => sale.Branch)
            .NotEmpty().WithMessage("Branch name must be provided.");

        RuleFor(sale => sale.SaleProducts)
            .Must(p => p.Count > 0).WithMessage("The sale must have at least one product.");
    }
}