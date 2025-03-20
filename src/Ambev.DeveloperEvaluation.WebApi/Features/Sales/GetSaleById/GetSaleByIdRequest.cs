namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetSaleByIdRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
