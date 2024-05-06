using DojoCat.Messaging.DataContracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace DoJoCat.Messaging.Consumers;

public class VerifyParentConsumer : IConsumer<VerifyParent>
{
    private readonly ILogger<VerifyParentConsumer> _logger;

    public VerifyParentConsumer(ILogger<VerifyParentConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<VerifyParent> context)
    {
        _logger.LogInformation("Verify parent message received for user {member}", context.Message.MemberName);
        return Task.CompletedTask;
    }
}
