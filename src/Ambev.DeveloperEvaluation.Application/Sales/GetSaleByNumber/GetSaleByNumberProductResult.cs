namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleByNumber;

/// <summary>
/// API response model for Product on GetSaleByNumber operation
/// </summary>
public class GetSaleByNumberProductResult
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
