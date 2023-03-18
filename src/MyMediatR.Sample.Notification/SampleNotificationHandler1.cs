using MediatR;
using Microsoft.Extensions.Logging;

namespace MyMediatR.Sample.Notification;
public class SampleNotificationHandler1 : INotificationHandler<SampleNotification>
{
    private readonly ILogger<SampleNotificationHandler1> _logger;

    public SampleNotificationHandler1(ILogger<SampleNotificationHandler1> logger)
    {
        _logger = logger;
    }
    public async Task Handle(SampleNotification notification, CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
        _logger.LogInformation("Notification 1 Sample: {Message}", notification.Message);
    }
}
