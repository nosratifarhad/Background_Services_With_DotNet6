using BackgroundServiceApplication.Services.Contract;

namespace BackgroundServiceApplication.Services
{
    public class SalaryCalculateService : ISalaryCalculateService
    {
        public async Task SalaryCalculateAsync()
        {
          await Task.Delay(1000);
        }
    }
}
