using DojoCat.Members.Common.DataContracts.Messaging;

namespace DojoCat.Members.Application.Interfacess;

public interface IMessageSender<T> where T : IBusMessage
{
    Task SendMessage(T message, CancellationToken cancellationToken);
}
