namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
/// API response model for Product on GetSaleById operation
/// </summary>
public class GetSaleByIdProductResponse
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
