using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackgroundServiceApplication.BackgroundWorkers;
using BackgroundServiceApplication.Services.Contracts;
using BackgroundServiceApplication.Services;
using BackgroundServiceApplication.Wrappers.Contracts;
using BackgroundServiceApplication.Wrappers;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                #region AddServices
                
                services.AddSingleton<ISalaryCalculateWrapper, SalaryCalculateWrapper>();
                services.AddSingleton<ISalaryCalculateService, SalaryCalculateService>();
                services.AddHostedService<SalaryCalculateBackgroundWorker>();
                
                #endregion AddServices
            });
}