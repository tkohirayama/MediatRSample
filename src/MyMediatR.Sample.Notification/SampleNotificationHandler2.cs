using MediatR;
using Microsoft.Extensions.Logging;

namespace MyMediatR.Sample.Notification;
public class SampleNotificationHandler2 : INotificationHandler<SampleNotification>
{
    private readonly ILogger<SampleNotificationHandler2> _logger;

    public SampleNotificationHandler2(ILogger<SampleNotificationHandler2> logger)
    {
        _logger = logger;
    }
    public async Task Handle(SampleNotification notification, CancellationToken cancellationToken)
    {
        await Task.Delay(2000, cancellationToken).ConfigureAwait(false);
        _logger.LogInformation("Notification 2 Sample: {Message}", notification.Message);
    }
}
