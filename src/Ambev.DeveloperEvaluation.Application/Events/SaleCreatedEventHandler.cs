using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Events;

public class SaleCreatedEventHandler(ILogger<SaleCreatedEventHandler> logger) : INotificationHandler<SaleCreatedEvent>
{
    private readonly ILogger<SaleCreatedEventHandler> _logger = logger;

    public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale Created: {SaleId}, Products: {ProductCount}",
            notification.Sale.Id, notification.Sale.SaleProducts.Count);

        return Task.CompletedTask;
    }
}
