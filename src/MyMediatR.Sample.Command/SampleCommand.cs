using MediatR;

namespace MyMediatR.Sample.Command;
public class SampleCommand : IRequest
{
    public SampleCommand(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
