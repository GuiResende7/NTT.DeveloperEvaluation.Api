using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    /// <summary>
    /// Sale number
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Date and time of the sale
    /// </summary>
    public DateTime SaleDate { get; private set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).ToUniversalTime();

    /// <summary>
    /// Customer name
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Total amount of the sale
    /// </summary>
    public decimal TotalAmount { get; private set; } = 0;

    /// <summary>
    /// Total amount of the sale with the discount value
    /// </summary>
    public decimal TotalAmountWithDiscount { get; private set; } = 0;

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Discount value applied to the sale
    /// </summary>
    public decimal Discount { get; private set; } = 0;

    /// <summary>
    /// Discount percentage applied to the sale
    /// </summary>
    public int DiscountPercentage { get; private set; } = 0;

    /// <summary>
    /// Indicates if the sale was canceled
    /// </summary>
    public bool Canceled { get; private set; } = false;

    /// <summary>
    /// List of products in the sale
    /// </summary>
    public List<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();

    /// <summary>
    /// Validate the Sale entity
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Calculate the possible discount percentage of the sale
    /// </summary>
    public int CalculateDiscountPercentage()
    {
        int discountPercentage = 0;
        // Apply discounts only if there are more than 3 products in the sale
        if (SaleProducts.Where(w => !w.Canceled).Sum(s => s.Quantity) > 3)
        {
            foreach (var saleProduct in SaleProducts)
            {
                if (saleProduct.Quantity > 4 && saleProduct.Quantity < 10)
                {
                    discountPercentage = 10;
                }

                if (saleProduct.Quantity >= 10 && saleProduct.Quantity <= 20)
                {
                    discountPercentage = 20;
                }
            }
        }

        return discountPercentage;
    }

    /// <summary>
    /// Validate the limit quantity of products in the sale
    /// </summary>
    public void ValidateProductLimits()
    {
        var saleLimited = SaleProducts.Where(w => w.Quantity > 20).ToList();
        if (saleLimited is not null && saleLimited.Any())
        {
            throw new InvalidOperationException($"The maximum quantity of the same products in a sale is 20 for the products: {string.Join(", ", saleLimited.Select(s => s.ProductId))}");
        }
    }

    /// <summary>
    /// Set the discount percentage and calculate the discount value of the sale
    /// </summary>
    public void SetSaleValue()
    {
        TotalAmount = SaleProducts.Where(w => !w.Canceled).Sum(p => p.Product?.UnitValue * p.Quantity) ?? 0;
        TotalAmountWithDiscount = TotalAmount - Discount;
    }

    /// <summary>
    /// Set the discount percentage and calculate the discount value of the sale
    /// </summary>
    public void SetDiscount(int percentage)
    {
        DiscountPercentage = percentage;
        Discount = TotalAmount * percentage / 100;
        TotalAmountWithDiscount = TotalAmount - Discount;
    }

    /// <summary>
    /// Cancel the sale
    /// </summary>
    public void Cancel()
    {
        Canceled = true;
    }
}
