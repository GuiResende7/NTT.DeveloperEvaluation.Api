namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleByNumber;

/// <summary>
/// Request model for getting a user by number
/// </summary>
public class GetSaleByNumberRequest
{
    /// <summary>
    /// The sale number
    /// </summary>
    public int Number { get; set; }
}
