namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
public class CreateProductResult
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