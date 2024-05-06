namespace DojoCat.Messaging.DataContracts;

public interface IBusMessage
{
    public string RoutingKey { get; }
}
