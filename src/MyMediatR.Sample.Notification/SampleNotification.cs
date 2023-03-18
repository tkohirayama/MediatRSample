using MediatR;

namespace MyMediatR.Sample.Notification;
public class SampleNotification : INotification
{
    public string Message { get; init; }
}
