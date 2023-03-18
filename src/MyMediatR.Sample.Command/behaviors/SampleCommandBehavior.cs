using MediatR;
using Microsoft.Extensions.Logging;

namespace MyMediatR.Sample.Command.behaviors;

public class SampleCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : SampleCommand
{
    private readonly ILogger<SampleCommandBehavior<TRequest, TResponse>> _logger;

    public SampleCommandBehavior(ILogger<SampleCommandBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"SampleCommandBehavior {typeof(TRequest).Name}");
        var response = await next();
        _logger.LogInformation($"SampleCommandBehavior {typeof(TResponse).Name}");

        return response;
    }
}
