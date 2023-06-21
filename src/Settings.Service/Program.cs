using Settings.Service;
using Settings.Service.Extensions;

var builder = WebApplication
    .CreateBuilder(args)
    .RegisterServices();

var app = builder
    .Build();

app.MapGet("/healthmonitor", () => "OK");


// TODO: Реализовать шифрование/дешифрование
app.MapPost("/encrypt", (string value) => value);
app.MapPost("/decrypt", (string value) => value);

/*
 * коректность конфига будет проверена тестами
 */
IConfigurationServiceFactory configurationServiceFactory = app
    .Services
    .GetRequiredService<IConfigurationServiceFactory>();


app.MapGet("/configuration/{serviceName}", (string serviceName) =>
    configurationServiceFactory
        .GetConfigurationService(serviceName)
        .Configuration);

app.Run();