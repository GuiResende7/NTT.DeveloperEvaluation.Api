namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new product.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Product unit value
    /// </summary>
    public decimal UnitValue { get; set; }
}
