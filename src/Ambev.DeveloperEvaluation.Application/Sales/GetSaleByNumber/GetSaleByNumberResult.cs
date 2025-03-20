namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleByNumber;

/// <summary>
/// Response model for GetSaleByNumber operation
/// </summary>
public class GetSaleByNumberResult
{
    /// <summary>
    /// The unique identifier of the created sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Date and time of the sale
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Customer name
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Sale number
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Sale total amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Sale total amount with discount
    /// </summary>
    public decimal TotalAmountWithDiscount { get; set; }

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
    /// Sale products
    /// </summary>
    public List<GetSaleByNumberProductResult> SaleProducts { get; set; } = new();
}
