namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Represents a request to cancel a sale item.
/// </summary>
public class CancelSaleItemRequest
{
    /// <summary>
    /// Sale unique identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product unique identifier
    /// </summary>
    public Guid ProductId { get; set; }
}
