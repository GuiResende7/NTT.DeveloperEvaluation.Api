namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

/// <summary>
/// Represents the response returned after of all products.
/// </summary>
public class GetAllProductsResult
{
    /// <summary>
    /// The unique identifier of the product.
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