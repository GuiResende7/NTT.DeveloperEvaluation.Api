namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
/// API response model for Product on GetSaleById operation
/// </summary>
public class GetSaleByIdProductResult
{
    /// <summary>
    /// Product unique identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Product unitary value
    /// </summary>
    public decimal UnitValue { get; set; }

    /// <summary>
    /// Item is canceled
    /// </summary>
    public bool Canceled { get; set; }

    /// <summary>
    /// Product quantity
    /// </summary>
    public int Quantity { get; set; }
}
