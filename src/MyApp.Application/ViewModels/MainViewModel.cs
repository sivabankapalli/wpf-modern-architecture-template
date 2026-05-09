using MyApp.Application.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyApp.Application.Commands;

namespace MyApp.Application.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly IDataService _service;
    private readonly ILogger<MainViewModel> _logger;

    private string _userName = "Click Load";

    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoadCommand { get; }

    public MainViewModel(IDataService service, ILogger<MainViewModel> logger)
    {
        _service = service;
        _logger = logger;
        LoadCommand = new AsyncRelayCommand(() => Load());
    }

    public async Task Load()
    {
        _logger.LogInformation("Loading user...");
        var user = await _service.GetUserAsync();
        UserName = user.Name;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}