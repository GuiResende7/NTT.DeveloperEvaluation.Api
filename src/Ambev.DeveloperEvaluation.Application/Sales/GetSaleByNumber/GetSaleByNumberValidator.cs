using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleByNumber;

/// <summary>
/// Validator for GetSaleByNumberCommand
/// </summary>
public class GetSaleByNumberValidator : AbstractValidator<GetSaleByNumberCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleByNumberCommand
    /// </summary>
    public GetSaleByNumberValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("Sale number is required");
    }
}
