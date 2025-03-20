namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new product sale in a sale request.
/// </summary>
public class CreateSaleProductRequest
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
