using Microsoft.EntityFrameworkCore;
using si730pc2u201624050.Infraestructure.Context;
using si730pc2u201624050.API.Mapper;
using si730pc2u201624050.Domain;
using si730pc2u201624050.Domain.Interfaces;
using si730pc2u201624050.Infraestructure;
using si730pc2u201624050.Infraestructure.Interfaces;

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
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31)); // CAMBIAR A LA VERSION QUE TENGA INSTALADA

builder.Services.AddDbContext<TravelersDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null));
    });

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
