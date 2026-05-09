namespace MyApp.Application.Interfaces;

public interface INavigationService
{
    void Navigate<TViewModel>();
}