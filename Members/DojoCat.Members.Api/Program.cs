using DojoCat.Members.Api.Configurations;
using DojoCat.Members.Api.Middleware;
using DojoCat.Members.Application.CommandHandlers;
using DojoCat.Members.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<INewMemberHandler, NewMemberHandler>();

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