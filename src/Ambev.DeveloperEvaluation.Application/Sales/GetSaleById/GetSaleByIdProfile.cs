using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
/// Profile for mapping between User entity and GetSaleByIdResponse
/// </summary>
public class GetSaleByIdProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleById operation
    /// </summary>
    public GetSaleByIdProfile()
    {
        CreateMap<Sale, GetSaleByIdResult>();
        CreateMap<SaleProduct, GetSaleByIdProductResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product != null ? src.Product.Id : default))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
            .ForMember(dest => dest.UnitValue, opt => opt.MapFrom(src => src.Product != null ? src.Product.UnitValue : 0));
    }
}
