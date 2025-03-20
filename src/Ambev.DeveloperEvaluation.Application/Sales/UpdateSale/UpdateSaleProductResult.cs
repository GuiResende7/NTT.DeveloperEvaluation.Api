namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleProductResult
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
    /// Total value of the product in the sale
    /// </summary>
    public decimal TotalAmount { get => Quantity * UnitValue; }
}
