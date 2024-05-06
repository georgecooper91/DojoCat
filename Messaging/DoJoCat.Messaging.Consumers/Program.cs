using DoJoCat.Messaging.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddLogging();

builder.Services.AddMassTransit(rabbitConfig => 
{
    rabbitConfig.SetKebabCaseEndpointNameFormatter();

    rabbitConfig.AddConsumer<VerifyParentConsumer>();


    rabbitConfig.UsingRabbitMq((context, config) => 
    {
        config.Host(builder.Configuration.GetValue<string>("RabbitMq:Host"), "/", creds => 
        {
            creds.Username("guest");
            creds.Password("guest");
        });

        //config.ConfigureMessageTopology(context);
        config.ReceiveEndpoint("receive-parent-request", x => 
        {
            x.ConfigureConsumeTopology = false;
            x.Consumer<VerifyParentConsumer>();
            x.Bind("dojocat-members", s => 
            {
                s.RoutingKey = "dojocat.members.validateparent";
                s.ExchangeType = ExchangeType.Direct;
                
            });
        });

        //config.ConfigureEndpoints(context);
    });


});

var host = builder.Build();
host.Run();
