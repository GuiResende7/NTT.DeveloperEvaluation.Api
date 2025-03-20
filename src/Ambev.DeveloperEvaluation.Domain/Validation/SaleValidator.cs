using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleDate)
            .NotEmpty().WithMessage("Sale date must be provided.");

        RuleFor(user => user.Customer)
            .NotEmpty().WithMessage("Customer name must be provided.")
            .MinimumLength(3).WithMessage("Customer name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Customer name cannot be longer than 50 characters.");

        RuleFor(sale => sale.TotalAmount)
            .GreaterThan(0).WithMessage("Total amount must be greater than zero.");

        RuleFor(sale => sale.Branch)
            .NotEmpty().WithMessage("Sale branch must be provided.");
    }
}
