namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command to create a sale product relation
/// </summary>
public class CreateSaleProductCommand
{
    /// <summary>
    /// Product unique identifier
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Quantity of the product in the sale
    /// </summary>
    public int Quantity { get; set; }
}
