namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

/// <summary>
/// API response model for GetAllProducts operation
/// </summary>
public class GetAllProductsResponse
{
    /// <summary>
    /// The unique identifier of the newly created product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Product unit value
    /// </summary>
    public decimal UnitValue { get; set; }
}
