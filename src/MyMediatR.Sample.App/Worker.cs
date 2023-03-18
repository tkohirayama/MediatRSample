using MediatR;
using MyMediatR.Sample.Command;
using MyMediatR.Sample.Stream;
using MyMediatR.Sample.Notification;

namespace MyMediatR.Sample.App;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMediator _mediator;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    public Worker(ILogger<Worker> logger, IMediator mediator, IHostApplicationLifetime hostApplicationLifetime)
    {
        _logger = logger;
        _mediator = mediator;
        _hostApplicationLifetime = hostApplicationLifetime;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const string msg = "Hello MediatR";

        // Send Command
        await SendCommand(msg);

        // Stream
        await CreateStream(msg);

        // Public Notificsation
        await PublishNotification(msg);

        _hostApplicationLifetime.StopApplication();
    }

    private async Task SendCommand(string msg)
    {
        SampleCommand command = new(msg);
        await _mediator.Send(command).ConfigureAwait(false);
    }

    private async Task CreateStream(string msg)
    {
        SampleStream aeCommand = new(msg);
        await foreach (var streamMessage in _mediator.CreateStream(aeCommand))
        {
            _logger.LogInformation("Stream Sample : {Message}", streamMessage);
        }
    }

    private async Task PublishNotification(string msg)
    {
        SampleNotification notification = new(msg);
        await _mediator.Publish(notification).ConfigureAwait(false);
    }
}
