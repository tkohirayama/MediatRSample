using MediatR;

namespace MyMediatR.Sample.Notification;
public class SampleNotification : INotification
{
    public SampleNotification(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
