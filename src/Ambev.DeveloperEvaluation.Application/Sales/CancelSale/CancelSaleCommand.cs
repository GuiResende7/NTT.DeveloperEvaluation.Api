using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Command to cancel a sale
/// </summary>
public class CancelSaleCommand : IRequest<CancelSaleResponse>
{
    /// <summary>
    /// Sale unique identifier
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Initializes a new instance of CancelSaleCommand
    /// </summary>
    /// <param name="id">The ID of the sale to delete</param>
    public CancelSaleCommand(Guid id)
    {
        Id = id;
    }
}