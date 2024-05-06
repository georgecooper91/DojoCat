using DojoCat.Members.Common.DataContracts.Messaging;
using MassTransit;
using RabbitMQ.Client;

namespace DojoCat.Members.Api.Extensions;

public static class MassTransitExtensions
{
    public static void ConfigureMessageTopology(this IRabbitMqBusFactoryConfigurator config, IBusRegistrationContext context)
    {
        config.Send<IBusMessage>(m =>
        {
            m.UseRoutingKeyFormatter(x => x.Message.RoutingKey);
        });

        config.Message<IBusMessage>(x => x.SetEntityName("dojocat-members"));

        config.Publish<IBusMessage>(x => 
        {
            x.ExchangeType = ExchangeType.Direct;               
        });
    }
}