namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleByNumber;

/// <summary>
/// API response model for Product on GetSaleByNumber operation
/// </summary>
public class GetSaleByNumberProductResponse
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
    /// Indicates if the sale product was canceled
    /// </summary>
    public bool Canceled { get; set; }

    /// <summary>
    /// Product unitary value
    /// </summary>
    public decimal UnitValue { get; set; }
}
