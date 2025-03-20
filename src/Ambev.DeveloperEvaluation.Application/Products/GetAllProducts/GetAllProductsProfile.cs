using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

/// <summary>
/// Profile for mapping between Product entities
/// </summary>
public class GetAllProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetAllProducts operation
    /// </summary>
    public GetAllProductsProfile()
    {
        CreateMap<Product, GetAllProductsResult>();
    }
}
