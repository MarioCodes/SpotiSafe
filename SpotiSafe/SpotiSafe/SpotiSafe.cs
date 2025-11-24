using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SpotiSafe;

public class SpotiSafe
{
    private readonly ILogger _logger;

    public SpotiSafe(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<SpotiSafe>();
    }

    [Function("BackupSpotiData")]
    public void Run([TimerTrigger("0 4 * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);
        
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation("Next timer schedule at: {nextSchedule}", myTimer.ScheduleStatus.Next);
        }
    }
}