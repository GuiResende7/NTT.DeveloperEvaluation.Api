using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleProduct : BaseEntity
{
    /// <summary>
    /// Product identifier
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Product of the sale
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Sale identifier
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Sale of the product
    /// </summary>
    public Sale? Sale { get; set; }

    /// <summary>
    /// Quantity of the product in the sale
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Flag to indicate if the sale item was canceled
    /// </summary>
    public bool Canceled { get; private set; } = false;

    public void CancelItem()
    {
        Canceled = true;
    }

    /// <summary>
    /// Validate the SaleProduct entity
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
