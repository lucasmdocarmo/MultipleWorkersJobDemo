using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ServiceWorkerCronJobDemo.Services
{
    public class JobServ1 : CronJobService
    {
        private readonly ILogger<JobServ1> _logger;

        public JobServ1(IScheduleConfig<JobServ1> config, ILogger<JobServ1> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob 1 is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
