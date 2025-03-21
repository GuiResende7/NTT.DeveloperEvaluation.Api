using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCancelatedEvent : INotification
{
    public Sale Sale { get; }

    public SaleCancelatedEvent(Sale sale)
    {
        Sale = sale;
    }
}