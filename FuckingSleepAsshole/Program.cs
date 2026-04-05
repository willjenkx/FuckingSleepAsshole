using FuckingSleepAsshole;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateApplicationBuilder();
host.Services.AddHostedService<YouThereService>();
host.Services.AddWindowsService();
var app = host.Build();
app.Run();
