using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for products creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    public CreateProductRequestValidator()
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