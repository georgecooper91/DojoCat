using MassTransit;
using RabbitMQ.Client;

namespace DoJoCat.Messaging.Consumers;

public static class MassTransitExtensions
{
    // public static void ConfigureMessageTopology(this IRabbitMqBusFactoryConfigurator config, IBusRegistrationContext context)
    // {
    //     config.ReceiveEndpoint("verify-parent", e =>
    //     {
    //         e.Bind("dojocat-members", x =>
    //         {
    //             x.Durable = false;
    //             x.AutoDelete = true;
    //             x.ExchangeType = ExchangeType.Topic;
    //             x.RoutingKey = "dojocat.members.validateparent";
    //         });

    //         e.ConfigureConsumer<VerifyParentConsumer>(context);
    //     });
    // }
}
