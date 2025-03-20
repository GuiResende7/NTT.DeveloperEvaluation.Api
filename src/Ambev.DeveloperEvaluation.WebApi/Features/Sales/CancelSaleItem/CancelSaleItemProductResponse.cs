namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// API response model for products on CancelSaleItem operation
/// </summary>
public class CancelSaleItemProductResponse
{
    /// <summary>
    /// Product identifier
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Quantity of the product in the sale
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Product unit value
    /// </summary>
    public decimal UnitValue { get; set; }

    /// <summary>
    /// Product is canceled
    /// </summary>
    public bool Canceled { get; set; }

    /// <summary>
    /// Total value of the product in the sale
    /// </summary>
    public decimal TotalAmount { get; set; }
}
