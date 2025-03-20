using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

/// <summary>
/// Profile for mapping between Application and API GetAllProducts responses
/// </summary>
public class GetAllProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetAllProducts feature
    /// </summary>
    public GetAllProductsProfile()
    {
        CreateMap<GetAllProductsResult, GetAllProductsResponse>();
    }
}
