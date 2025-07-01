using GP.API.Tower.Consumer;
using GP.API.Tower.Model;
using GP.API.Tower.Repository;
using GP.API.Tower.Repository.Implementation;
using GP.API.Tower.Services;
using GP.API.Tower.Services.Implementation;
using GP.LIB.Messages.Implementation;
using GP.LIB.Messages.Interface;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var config = new ConfigurationBuilder()
 .SetBasePath(AppContext.BaseDirectory)
 .AddJsonFile("appsettings.json", optional: false)
 .AddUserSecrets<Program>()
 .Build();
string azureServiceBusConnectionString = config["AzureServiceBus:ConnnectionString"];

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessagePublisher, MessagePublisher>();
builder.Services.AddScoped<IShipPositionUpdatedConsumer, ShipPositionUpdatedConsumer>();
builder.Services.AddScoped<IShipPositionRepository, ShipPositionRepository>();
builder.Services.AddScoped<IShipPositionService, ShipPositionService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ShipConsumer>();

    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(azureServiceBusConnectionString);

        cfg.ReceiveEndpoint("_GP.API.Tower-Queue", e =>
        {
            e.ConfigureConsumer<ShipConsumer>(context);
        });
    });
});

// Pour démarrer le bus automatiquement
builder.Services.AddMassTransitHostedService();

var connectionString = config.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TowerDbContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

app.UseHttpsRedirection();  // HTTPS redirection middleware
app.UseAuthorization();     // Authorization middleware 
app.MapControllers();       // Map controllers to routes
app.UseRouting();           // Enable routing

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
