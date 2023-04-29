using BackgroundServiceApplication.Helpers;
using BackgroundServiceApplication.Services.Contract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BackgroundServiceApplication.BackgroundWorkers;

public class SalaryCalculateBackgroundWorker : BackgroundService
{
    #region Fields
    private readonly ISalaryCalculateService _salaryCalculateService;
    #endregion Fields

    #region Ctor

    public SalaryCalculateBackgroundWorker(
        ISalaryCalculateService salaryCalculateService,
        IOptions<OrderingBackgroundSetting> settings)
    {
        this._salaryCalculateService = salaryCalculateService;
        this._settings = settings.Value;
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
        try
        {
            await DoWork(stoppingToken);
        }
        catch (Exception exception)
        {
            //exception 
        }
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _salaryCalculateService.SalaryCalculateAsync();

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}

