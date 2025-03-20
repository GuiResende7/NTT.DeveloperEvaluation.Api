using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleProductValidator : AbstractValidator<SaleProduct>
{
    public SaleProductValidator()
    {
        RuleFor(sp => sp.ProductId)
            .NotEmpty().WithMessage("Product Id must be provided.");

        RuleFor(sp => sp.SaleId)
            .NotEmpty().WithMessage("Sale Id must be provided.");

        RuleFor(sp => sp.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}
