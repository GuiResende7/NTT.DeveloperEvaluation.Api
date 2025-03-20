namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to update a sale in the system.
/// </summary>
public class UpdateSaleRequest
{
    /// <summary>
    /// Sale unique identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Customer name
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string? Branch { get; set; }
}