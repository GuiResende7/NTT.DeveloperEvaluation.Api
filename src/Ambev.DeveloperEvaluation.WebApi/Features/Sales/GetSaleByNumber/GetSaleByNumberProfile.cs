using Ambev.DeveloperEvaluation.Application.Sales.GetSaleByNumber;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleByNumber;

/// <summary>
/// Profile for mapping GetSaleByNumber feature requests to commands
/// </summary>
public class GetSaleByNumberProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleByNumber feature
    /// </summary>
    public GetSaleByNumberProfile()
    {
        CreateMap<int, GetSaleByNumberCommand>()
            .ConstructUsing(number => new GetSaleByNumberCommand(number));
        CreateMap<GetSaleByNumberResult, GetSaleByNumberResponse>();
        CreateMap<GetSaleByNumberProductResult, GetSaleByNumberProductResponse>();
    }
}
