using Microsoft.Extensions.Hosting;

namespace FuckingSleepAsshole;

public sealed class YouThereService : BackgroundService
{
    private DateTime LastSeen { get; set; } = DateTime.Now;
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var lastPos = WhereMouse.GetPosition();
        while (!stoppingToken.IsCancellationRequested)
        {
            var mousePos = WhereMouse.GetPosition();
            
            if (lastPos != mousePos)
                LastSeen = DateTime.Now;

            if (LastSeen.AddMinutes(60) < DateTime.Now)
            {
                LastSeen = DateTime.Now;
                TimeToSleep.Now();
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}