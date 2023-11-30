
namespace AsyncLogReqRes
{
    public class WorkerPubLogger : BackgroundService
    {

        private readonly ILogger<WorkerPubLogger> _logger;

        public WorkerPubLogger(ILogger<WorkerPubLogger> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
