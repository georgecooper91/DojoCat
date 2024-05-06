using DojoCat.Members.Api.Configurations;
using DojoCat.Members.Api.Extensions;
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
                creds.Username(builder.Configuration.GetValue<string>("RabbitMq:Username"));
                creds.Password(builder.Configuration.GetValue<string>("RabbitMq:Password"));
            });

        config.ConfigureMessageTopology(context);
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
