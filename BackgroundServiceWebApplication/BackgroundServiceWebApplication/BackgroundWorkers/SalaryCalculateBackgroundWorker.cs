using BackgroundServiceWebApplication.Helpers;
using BackgroundServiceWebApplication.Services.Contract;
using Microsoft.Extensions.Options;

namespace BackgroundServiceWebApplication.BackgroundWorkers;

public class SalaryCalculateBackgroundWorker : BackgroundService
{
    #region Fields
    private readonly ILogger<SalaryCalculateBackgroundWorker> _logger;
    private readonly ISalaryCalculateService _salaryCalculateService;
    private readonly OrderingBackgroundSetting _settings;
    #endregion Fields

    #region Ctor

    public SalaryCalculateBackgroundWorker(
        ILogger<SalaryCalculateBackgroundWorker> logger,
        ISalaryCalculateService salaryCalculateService,
        IOptions<OrderingBackgroundSetting> settings)
    {
        this._salaryCalculateService = salaryCalculateService;
        this._settings = settings.Value;
        this._logger = logger;
    }
    #endregion Ctor

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        return base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await DoWork(stoppingToken);
            }
            catch (TaskCanceledException exception)
            {

            }
        }
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _salaryCalculateService.SalaryCalculateAsync();
            await Task.Delay(TimeSpan.FromSeconds(_settings.WorkerIntervalSec), stoppingToken);
        }
    }
}

