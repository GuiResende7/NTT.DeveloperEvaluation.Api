namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// API response model for CancelSale operation
/// </summary>
public class CancelSaleResponse
{
    /// <summary>
    /// The unique identifier of the created sale
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Sale number
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Sale total amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Discount value applied to the sale
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Discount percentage applied to the sale
    /// </summary>
    public int DiscountPercentage { get; set; }

    /// <summary>
    /// Indicates if the sale was canceled
    /// </summary>
    public bool Canceled { get; set; }
}
