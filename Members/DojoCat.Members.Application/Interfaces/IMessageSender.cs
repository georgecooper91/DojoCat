using DojoCat.Messaging.DataContracts;

namespace DojoCat.Members.Application.Interfacess;

public interface IMessageSender<T> where T : IBusMessage
{
    Task SendMessage(T message, CancellationToken cancellationToken);
}
