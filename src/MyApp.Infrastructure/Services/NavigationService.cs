using MyApp.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Infrastructure.Services;

public class NavigationService(IServiceProvider provider) : INavigationService
{
    public void Navigate<TViewModel>()
    {
        var vm = provider.GetRequiredService<TViewModel>();
        // Extend for real navigation
    }
}