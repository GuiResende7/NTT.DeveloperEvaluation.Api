using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
/// Command to get a sale by the Id
/// </summary>
public class GetSaleByIdCommand : IRequest<GetSaleByIdResult>
{
    /// <summary>
    /// Sale unique identifier
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Initializes a new instance of GetSaleByIdCommand
    /// </summary>
    /// <param name="id">The ID of the sale</param>
    public GetSaleByIdCommand(Guid id)
    {
        Id = id;
    }
}