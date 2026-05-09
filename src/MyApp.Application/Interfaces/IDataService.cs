using MyApp.Domain;

namespace MyApp.Application.Interfaces;

public interface IDataService
{
    Task<User> GetUserAsync();
}