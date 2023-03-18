using MediatR;

namespace MyMediatR.Sample.Stream;
public class SampleStream : IStreamRequest<string>
{
    public SampleStream(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
