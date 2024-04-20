using DojoCat.Members.Api.Configurations;
using DojoCat.Members.Api.Middleware;
using DojoCat.Members.Application.CommandHandlers;
using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Application.Interfacess;
using DojoCat.Members.Application.QueryHandlers;
using DojoCat.Members.Application.Services;
using DojoCat.Members.Common.DataContracts.Messaging;
using DojoCat.Members.Common.User;
using DojoCat.Members.Domain.Interfaces;
using DojoCat.Members.Domain.Utilities;
using DojoCat.Members.Infrastructure.Database;
using DojoCat.Members.Infrastructure.Executors;
using DojoCat.Members.Infrastructure.Executors.Queries;
using DojoCat.Members.Infrastructure.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddTransient<DojoCatUserProvider>();
builder.Services.AddTransient<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddTransient<INewMemberHandler, NewMemberHandler>();
builder.Services.AddTransient<INewMemberExecutor, NewMemberExecutor>();
builder.Services.AddTransient<IGetMemberHandler, GetMemberHandler>();
builder.Services.AddTransient<IGetMemberExecutor, GetMemberExecutor>();
builder.Services.AddTransient<INewParentHandler, NewParentHandler>();
builder.Services.AddTransient<INewParentExecutor, NewParentExecutor>();
builder.Services.AddTransient<IFindMembersHandler, FindMembersHandler>();
builder.Services.AddTransient<IFindMembersExecutor, FindMembersExecutor>();
builder.Services.AddTransient<IAddMemberParentAssociationExecutor, AddMemberParentAssociationExecutor>();
builder.Services.AddTransient<IMatchMembersToParents, MatchMembersToParents>();

builder.Services.AddDbContext<MembersDbContext>(opt 
    => opt.UseNpgsql(builder.Configuration.GetConnectionString("MembersDatabase")));

builder.Services.AddMassTransit(rabbitConfig => 
{
    rabbitConfig.SetKebabCaseEndpointNameFormatter();
    rabbitConfig.UsingRabbitMq((context, config) => 
        {
            config.Host(builder.Configuration.GetValue<string>("RabbitMq:Host"), "/", creds => 
                {
                    creds.Username("guest");
                    creds.Password("guest");
                });
            // config.ReceiveEndpoint("verify-parent-n", e =>
            // {
            //     e.Bind<VerifyParent>(ex => {
            //         ex.Durable = false;
            //         ex.AutoDelete = true;
            //         ex.ExchangeType = ExchangeType.Direct;
            //         ex.RoutingKey = "dojocat.members.validateparent";
            //     });
                // e.Bind("dojocat-members", x =>
                // {
                //     x.Durable = false;
                //     x.AutoDelete = true;
                //     x.ExchangeType = ExchangeType.Topic;
                //     x.RoutingKey = "dojocat.members.validateparent";
                // });
           // });
            // config.Send<IBusMessage>(m =>
            // {
            //     m.UseRoutingKeyFormatter(x => x.Message.RoutingKey);
            // });
             config.Message<VerifyParent>(x => x.SetEntityName("dojocat-members"));
            // config.Publish<VerifyParent>(x => {
            //     x.ExchangeType = ExchangeType.Topic;
            //     // x.BindQueue("DojoCat.Members.Common.DataContracts.Messaging:IBusMessage", "verify-parent-new", x => {
            //     //     x.RoutingKey = "dojocat.members.validateparent";
            //     // });
            //     });
        });
});

builder.Services.AddScoped<IMessageSender<VerifyParent>, MessageSender<VerifyParent>>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddLogging(builder => builder.AddConsole());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCancellation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
