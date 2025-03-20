using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Command to cancel a sale item
/// </summary>
public class CancelSaleItemCommand : IRequest<CancelSaleItemResult>
{
    /// <summary>
    /// Sale unique identifier
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Product unique identifier
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Initializes a new instance of CancelSaleItemCommand
    /// </summary>
    /// <param name="id">The ID of the sale to delete</param>
    public CancelSaleItemCommand(Guid id, Guid productId)
    {
        Id = id;
        ProductId = productId;
    }
}