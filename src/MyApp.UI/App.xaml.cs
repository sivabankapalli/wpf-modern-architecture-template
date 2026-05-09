using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Windows;
using MyApp.Application.Interfaces;
using MyApp.Infrastructure.Services;
using MyApp.Application.ViewModels;

namespace MyApp.UI;

public partial class App : System.Windows.Application
{
    public static IHost Host { get; private set; }

    public App()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("appsettings.json", optional: false);
            })
            .UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration)
                      .WriteTo.Console();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<INavigationService, NavigationService>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        DispatcherUnhandledException += (s, e) =>
        {
            Log.Error(e.Exception, "UI Exception");
            e.Handled = true;
        };

        await Host.StartAsync();

        var window = Host.Services.GetRequiredService<MainWindow>();
        window.Show();
    }
}