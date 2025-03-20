using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleByNumber;

/// <summary>
/// Command to get a sale by the number
/// </summary>
public class GetSaleByNumberCommand : IRequest<GetSaleByNumberResult>
{
    /// <summary>
    /// Sale number
    /// </summary>
    public int Number { get; private set; }

    /// <summary>
    /// Initializes a new instance of GetSaleByNumberCommand
    /// </summary>
    /// <param name="number">The number of the sale</param>
    public GetSaleByNumberCommand(int number)
    {
        Number = number;
    }
}