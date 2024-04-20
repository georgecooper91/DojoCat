namespace DojoCat.Members.Common.DataContracts.Messaging;

public interface IBusMessage
{
    public string RoutingKey { get; }
}
