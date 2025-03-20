using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command to create a sale
/// </summary>
public class CreateSaleCommand : IRequest<CreateSaleResult>
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
    public List<CreateSaleProductCommand> SaleProducts { get; set; } = new();
}