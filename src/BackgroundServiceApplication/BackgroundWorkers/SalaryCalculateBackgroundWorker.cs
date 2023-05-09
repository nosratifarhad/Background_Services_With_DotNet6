using BackgroundServiceApplication.Helpers;
using BackgroundServiceApplication.Services.Contract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace BackgroundServiceApplication.BackgroundWorkers;

public class SalaryCalculateBackgroundWorker : BackgroundService
{
    #region Fields
    private readonly ISalaryCalculateService _salaryCalculateService;
    private readonly OrderingBackgroundSetting _settings;

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

    #region [ Private ]

    private async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await _salaryCalculateService.SalaryCalculateAsync();

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                //Console.WriteLine($"Run DoWork Method In Back Ground");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Call Salary Api For Calculate Personnel Salary In This time : {DateTime.Now}");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
    }

    #endregion [ Private ]
}

