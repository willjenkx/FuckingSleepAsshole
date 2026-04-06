using FuckingSleepAsshole;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateApplicationBuilder();
host.Services.AddHostedService<YouThereService>();
var app = host.Build();
app.Run();
