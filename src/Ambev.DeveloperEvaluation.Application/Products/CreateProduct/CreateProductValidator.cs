using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for sales creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name must be provided.")
            .MinimumLength(3).WithMessage("Product name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Product name cannot be longer than 50 characters.");

        RuleFor(p => p.UnitValue)
            .NotEmpty().WithMessage("Product unit value must be provided.")
            .GreaterThan(0).WithMessage("Product unit value must be greater than zero.");
    }
}