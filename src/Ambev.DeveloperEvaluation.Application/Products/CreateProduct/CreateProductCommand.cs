using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command to create a product
/// </summary>
public class CreateProductCommand : IRequest<CreateProductResult>
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