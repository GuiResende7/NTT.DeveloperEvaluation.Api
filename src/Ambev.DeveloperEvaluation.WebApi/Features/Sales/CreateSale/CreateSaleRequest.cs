namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Customer name
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// List of products in the sale
    /// </summary>
    public List<CreateSaleProductRequest> SaleProducts { get; set; } = new();
}