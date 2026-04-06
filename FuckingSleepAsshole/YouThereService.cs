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
                TimeToSleep.Now();
                // I'm not sure where the code will be executing at this point, so just a lil delay
                await Task.Delay(5000, stoppingToken);
                // this will hopefully prevent an infinite sleep loop :)
                LastSeen = DateTime.Now;
            }

            
            lastPos = mousePos;
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}