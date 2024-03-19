using DojoCat.Members.Api.Configurations;
using DojoCat.Members.Api.Middleware;
using DojoCat.Members.Application.CommandHandlers;
using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Common.User;
using DojoCat.Members.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddTransient<DojoCatUserProvider>();
builder.Services.AddTransient<INewMemberHandler, NewMemberHandler>();

builder.Services.AddDbContext<MembersDbContext>(opt 
    => opt.UseNpgsql(builder.Configuration.GetConnectionString("MembersDatabase")));

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
