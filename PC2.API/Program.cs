using Microsoft.EntityFrameworkCore;
using si730pc2u201624050.Infraestructure.Context;
using si730pc2u201624050.API.Mapper;
using si730pc2u201624050.Domain;
using si730pc2u201624050.Domain.Interfaces;
using si730pc2u201624050.Infraestructure;
using si730pc2u201624050.Infraestructure.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDestinationInfrastructure, DestinationInfrastructure>();
builder.Services.AddScoped<IDestinationDomain, DestinationDomain>();

// IMPORTANTEEEEEE
var connectionString = builder.Configuration.GetConnectionString("TravelersCS");
builder.Services.AddDbContext<TravelersDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
