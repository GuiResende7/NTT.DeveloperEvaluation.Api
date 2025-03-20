namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// Represents a request to cancel a sale.
/// </summary>
public class CancelSaleRequest
{
    /// <summary>
    /// Sale unique identifier
    /// </summary>
    public Guid Id { get; set; }
}
