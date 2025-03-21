using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Events;

public class SaleProductCancelatedEventHandler(ILogger<SaleProductCancelatedEventHandler> logger) : INotificationHandler<SaleProductCancelatedEvent>
{
    private readonly ILogger<SaleProductCancelatedEventHandler> _logger = logger;

    public Task Handle(SaleProductCancelatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale Modified: {SaleId}, Product cancelated: {ProductId}",
            notification.SaleProduct.SaleId, notification.SaleProduct.ProductId);

        return Task.CompletedTask;
    }
}
