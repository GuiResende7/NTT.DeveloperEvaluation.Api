using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleProductCancelatedEvent : INotification
{
    public SaleProduct SaleProduct { get; }

    public SaleProductCancelatedEvent(SaleProduct saleProduct)
    {
        SaleProduct = saleProduct;
    }
}