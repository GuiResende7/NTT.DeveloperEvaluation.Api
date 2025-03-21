using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Product name must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Product name cannot be longer than 100 characters.");

        RuleFor(product => product.UnitValue)
            .NotEmpty().WithMessage("Product unit value must be provided.")
            .GreaterThan(0).WithMessage("Product unit value must be greater than zero.");
    }
}
