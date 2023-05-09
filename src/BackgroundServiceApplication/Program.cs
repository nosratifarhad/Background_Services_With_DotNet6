using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackgroundServiceApplication.BackgroundWorkers;
using BackgroundServiceApplication.Services.Contract;
using BackgroundServiceApplication.Services;

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
                
                services.AddSingleton<ISalaryCalculateService, SalaryCalculateService>();
                services.AddHostedService<SalaryCalculateBackgroundWorker>();
                
                #endregion AddServices
            });
}