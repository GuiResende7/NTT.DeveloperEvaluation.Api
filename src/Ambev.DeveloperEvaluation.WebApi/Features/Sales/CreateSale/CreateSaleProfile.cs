using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleProductRequest, CreateSaleProductCommand>();
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<CreateSaleProductResult, CreateSaleProductResponse>();
    }
}
