using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Sale entities
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleProductCommand, SaleProduct>();
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<Sale, CreateSaleResult>();
        CreateMap<SaleProduct, CreateSaleProductResult>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
            .ForMember(dest => dest.UnitValue, opt => opt.MapFrom(src => src.Product != null ? src.Product.UnitValue : 0));
    }
}
