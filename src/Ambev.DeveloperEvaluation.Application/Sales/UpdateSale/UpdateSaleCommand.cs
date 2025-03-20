using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command to create a sale
/// </summary>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
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