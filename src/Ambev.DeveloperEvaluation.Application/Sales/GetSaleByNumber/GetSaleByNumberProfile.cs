using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleByNumber;

/// <summary>
/// Profile for mapping between User entity and GetSaleByNumberResponse
/// </summary>
public class GetSaleByNumberProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleByNumber operation
    /// </summary>
    public GetSaleByNumberProfile()
    {
        CreateMap<Sale, GetSaleByNumberResult>();
        CreateMap<SaleProduct, GetSaleByNumberProductResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product != null ? src.Product.Id : default))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
            .ForMember(dest => dest.UnitValue, opt => opt.MapFrom(src => src.Product != null ? src.Product.UnitValue : 0));
    }
}
