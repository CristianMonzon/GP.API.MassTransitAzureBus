using GP.API.Ship.Services;
using GP.API.Ship.Services.Implementation;
using GP.LIB.Messages.Implementation;
using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus.Ship;
using MassTransit;

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

builder.Services.AddScoped<ILogger<MessagePublisher>, Logger<MessagePublisher>>();
builder.Services.AddScoped<IMessagePublisher, MessagePublisher>();
builder.Services.AddScoped<IShipService, ShipService>();

builder.Services.AddMassTransit(x =>
{
    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(azureServiceBusConnectionString);
    });
});

// Pour démarrer le bus automatiquement
builder.Services.AddMassTransitHostedService();

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
