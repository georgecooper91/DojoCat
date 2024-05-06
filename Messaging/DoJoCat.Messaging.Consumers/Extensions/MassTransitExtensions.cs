using DoJoCat.Messaging.Domain.Constants;
using MassTransit;
using RabbitMQ.Client;

namespace DoJoCat.Messaging.Consumers;

public static class MassTransitExtensions
{
    public static void ConfigureMessageTopology(this IRabbitMqBusFactoryConfigurator config, IBusRegistrationContext context)
    {
        config.ReceiveEndpoint("receive-validate-parent-request", x => 
        {
            x.ConfigureConsumeTopology = false;
            x.Consumer<VerifyParentConsumer>(context);
            x.Bind("dojocat-members", s => 
            {
                s.RoutingKey = RoutingKeys.ValidateParent;
                s.ExchangeType = ExchangeType.Direct;                
            });
        });
    }
}
