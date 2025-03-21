using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Events;

public class SaleModifiedEventHandler(ILogger<SaleModifiedEventHandler> logger) : INotificationHandler<SaleModifiedEvent>
{
    private readonly ILogger<SaleModifiedEventHandler> _logger = logger;

    public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale Modified: {SaleId}, Customer: {Customer}, Branch: {Branch}",
            notification.Sale.Id, notification.Sale.Customer, notification.Sale.Branch);

        return Task.CompletedTask;
    }
}
