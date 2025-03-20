using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

/// <summary>
/// Handler for processing GetAllProductsCommand requests
/// </summary>
public class GetAllProductsHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetAllProductsCommand, List<GetAllProductsResult>>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Handles the GetAllProductsCommand request
    /// </summary>
    /// <param name="command">The GetAllProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>All products in the database</returns>
    public async Task<List<GetAllProductsResult>> Handle(GetAllProductsCommand command, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAll(cancellationToken);
        if (products is null || !products.Any())
        {
            throw new InvalidOperationException("No products found in the database");
        }

        return _mapper.Map<List<GetAllProductsResult>>(products);
    }
}
