using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Profile for mapping between Sale entities
/// </summary>
public class CancelSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CancelSaleItem operation
    /// </summary>
    public CancelSaleItemProfile()
    {
        CreateMap<Sale, CancelSaleItemResult>();
        CreateMap<SaleProduct, CancelSaleItemProductResult>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
            .ForMember(dest => dest.UnitValue, opt => opt.MapFrom(src => src.Product != null ? src.Product.UnitValue : 0));
    }
}
