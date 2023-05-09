using BackgroundServiceApplication.Wrappers.Contracts;

namespace BackgroundServiceApplication.Wrappers;

public class SalaryCalculateWrapper : ISalaryCalculateWrapper
{
    public async Task SalaryCalculateAsync()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Calculate Personnel Salary In Samery Subsystem In This Time {DateTime.Now} \n");
        await Task.Delay(1000);
    }
}
