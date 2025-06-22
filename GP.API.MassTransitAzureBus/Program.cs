using Microsoft.Extensions.Configuration;
using GP.API.MassTransitAzureBus.Consumer;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);


var config = new ConfigurationBuilder()
 .SetBasePath(AppContext.BaseDirectory)
 .AddJsonFile("appsettings.json", optional: false)
 .Build();
string azureServiceBusConnectionString = config["AzureServiceBus:ConnnectionString"];

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PersonConsumer>();

    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(azureServiceBusConnectionString);

        cfg.ReceiveEndpoint("_GP.API.Person-Queue", e =>
        {
            e.ConfigureConsumer<PersonConsumer>(context);
        });
    });
});

// Pour démarrer le bus automatiquement
builder.Services.AddMassTransitHostedService(); 


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
