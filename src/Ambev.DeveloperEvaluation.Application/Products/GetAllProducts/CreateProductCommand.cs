using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

/// <summary>
/// Command to get all products
/// </summary>
public class GetAllProductsCommand : IRequest<List<GetAllProductsResult>> { }