using MyApp.Application.Interfaces;
using MyApp.Domain;

namespace MyApp.Infrastructure.Services;

public class DataService : IDataService
{
    public async Task<User> GetUserAsync()
    {
        await Task.Delay(300);
        return new User { Name = "Enterprise WPF User" };
    }
}