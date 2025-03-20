namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully updating a sale.
/// </summary>
public class UpdateSaleResult
{
    /// <summary>
    /// The unique identifier of the newly created sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Sale number
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Date and time of the sale
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Customer name
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Total amount of the sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Total amount of the sale with the discount value
    /// </summary>
    public decimal TotalAmountWithDiscount { get; set; }

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

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

    /// <summary>
    /// List of products in the sale
    /// </summary>
    public List<UpdateSaleProductResult> SaleProducts { get; set; } = new();
}