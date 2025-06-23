using GP.API.MassTransitAzureBus.Consumer;
using GP.LIB.Messages.Impl;
using GP.LIB.Messages.Interface;
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

builder.Services.AddScoped<IPersonMessagePublisher, PersonMessagePublisher>();
builder.Services.AddScoped<IPersonMessageConsumer, PersonMessageConsumer>();

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
