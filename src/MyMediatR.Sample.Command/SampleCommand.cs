using MediatR;

namespace MyMediatR.Sample.Command;
public class SampleCommand : IRequest
{
    public string Message { get; init; }
}
