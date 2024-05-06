using DojoCat.Members.Application.Interfacess;
using DojoCat.Messaging.DataContracts;
using MassTransit;

namespace DojoCat.Members.Application.Services;

public class MessageSender<T> : IMessageSender<T> where T : IBusMessage
{
    private readonly IPublishEndpoint _sender;
    
    public MessageSender(IPublishEndpoint sender)
    {
        _sender = sender;
    }

    public async Task SendMessage(T message, CancellationToken cancellationToken)
    {
        await _sender.Publish(message, cancellationToken);
    }
}
