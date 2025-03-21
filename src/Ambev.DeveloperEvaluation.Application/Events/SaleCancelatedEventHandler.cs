using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Events;

public class SaleCancelatedEventHandler(ILogger<SaleCancelatedEventHandler> logger) : INotificationHandler<SaleCancelatedEvent>
{
    private readonly ILogger<SaleCancelatedEventHandler> _logger = logger;

    public Task Handle(SaleCancelatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale Cancelated: {SaleId}",
            notification.Sale.Id);

        return Task.CompletedTask;
    }
}
