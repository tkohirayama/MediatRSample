using MediatR;
using Microsoft.Extensions.Logging;
using MyMediatR.Sample.Command;

namespace MyMediatR.Sample.CommandImpl;
public class SampleCommandHandler : IRequestHandler<SampleCommand>
{
    private readonly ILogger<SampleCommandHandler> _logger;

    public SampleCommandHandler(ILogger<SampleCommandHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(SampleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Command Sample: {Message}", request.Message);
        return Task.CompletedTask;
    }
}
