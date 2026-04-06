using Microsoft.Extensions.Hosting;

namespace FuckingSleepAsshole;

public sealed class YouThereService : BackgroundService
{
    private DateTime LastSeen { get; set; } = DateTime.UtcNow;
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var lastPos = WhereMouse.GetPosition();
        while (!stoppingToken.IsCancellationRequested)
        {
            var mousePos = WhereMouse.GetPosition();
            
            if (lastPos != mousePos)
                LastSeen = DateTime.UtcNow;

            if (LastSeen.AddMinutes(60) < DateTime.UtcNow)
            {
                TimeToSleep.Now();
                // I'm not sure where the code will be executing at this point, so just a lil delay
                await Task.Delay(5000, stoppingToken);
                // this will hopefully prevent an infinite sleep loop :)
                LastSeen = DateTime.UtcNow;
            }

            
            lastPos = mousePos;
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}