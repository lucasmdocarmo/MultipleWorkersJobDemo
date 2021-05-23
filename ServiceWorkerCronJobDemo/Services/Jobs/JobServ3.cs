using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ServiceWorkerCronJobDemo.Services
{
    public class JobServ3 : CronJobService
    {
        private readonly ILogger<JobServ3> _logger;

        public JobServ3(IScheduleConfig<JobServ3> config, ILogger<JobServ3> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 3 starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob 3 is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 3 is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
