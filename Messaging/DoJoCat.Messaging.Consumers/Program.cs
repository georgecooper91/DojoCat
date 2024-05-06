using DoJoCat.Messaging.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddLogging();

builder.Services.AddMassTransit(rabbitConfig => 
{
    rabbitConfig.SetKebabCaseEndpointNameFormatter();

    rabbitConfig.UsingRabbitMq((context, config) => 
    {
        config.Host(builder.Configuration.GetValue<string>("RabbitMq:Host"), "/", creds => 
        {
            creds.Username(builder.Configuration.GetValue<string>("RabbitMq:Username"));
            creds.Password(builder.Configuration.GetValue<string>("RabbitMq:Password"));
        });

        config.ConfigureMessageTopology(context);
    });
});

var host = builder.Build();
host.Run();