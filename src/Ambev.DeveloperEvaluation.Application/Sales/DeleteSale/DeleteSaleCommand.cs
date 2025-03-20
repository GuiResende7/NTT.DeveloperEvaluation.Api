using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command to delete a sale
/// </summary>
public class DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    /// <summary>
    /// Sale unique identifier
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Initializes a new instance of DeleteSaleCommand
    /// </summary>
    /// <param name="id">The ID of the sale to delete</param>
    public DeleteSaleCommand(Guid id)
    {
        Id = id;
    }
}