using MyApp.Application.ViewModels;
using System.Windows;

namespace MyApp.UI;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}