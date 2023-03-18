using MediatR;
using MyMediatR.Sample.Command;
using MyMediatR.Sample.Stream;
using MyMediatR.Sample.Notification;

namespace MyMediatR.Sample.App;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMediator _mediator;

    public Worker(ILogger<Worker> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string message = "Hello MediatR";

        // Send Command
        await SendCommand(message);

        // Stream
        // await CreateStream(message);

        // Public Notificsation
        // await PublishNotification(message);
    }

    private async Task SendCommand(string message)
    {
        SampleCommand command = new()
        {
            Message = message
        };
        // Console.WriteLine("Start Command Sample.");
        await _mediator.Send(command).ConfigureAwait(false);
        // Console.WriteLine("Finish Command Sample.");
    }

    private async Task CreateStream(string message)
    {
        SampleStream aeCommand = new();
        // Console.WriteLine("Start Stream Sample.");
        await foreach (var aeMessage in _mediator.CreateStream(aeCommand))
        {
            Console.WriteLine($"{message} : {aeMessage}");
        }
        // Console.WriteLine("Finish Stream Sample.");
    }

    private async Task PublishNotification(string message)
    {
        SampleNotification notification = new()
        {
            Message = message
        };
        // Console.WriteLine("Start Notification Sample.");
        await _mediator.Publish(notification).ConfigureAwait(false);
        // Console.WriteLine("Finish Notification Sample.");
    }
}
