using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
/// Profile for mapping GetSaleById feature requests to commands
/// </summary>
public class GetSaleByIdProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleById feature
    /// </summary>
    public GetSaleByIdProfile()
    {
        CreateMap<Guid, GetSaleByIdCommand>()
            .ConstructUsing(id => new GetSaleByIdCommand(id));
        CreateMap<GetSaleByIdResult, GetSaleByIdResponse>();
        CreateMap<GetSaleByIdProductResult, GetSaleByIdProductResponse>();
    }
}
