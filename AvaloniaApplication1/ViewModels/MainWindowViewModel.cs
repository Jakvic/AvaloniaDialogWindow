using System.Diagnostics;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Avalonia.Threading;
using AvaloniaApplication1.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        ShowDialogCommand = ReactiveCommand.Create(ShowDialog);
    }

    [Reactive]
    public string Greeting { get; set; } = "Welcome to Avalonia!";

    public ReactiveCommand<Unit, Unit> ShowDialogCommand { get; }

    private void ShowDialog()
    {
        Greeting = "Fuck Avalonia";
        Debug.WriteLine("Binding Ok!");
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
        {
            return;
        }

        var dialogView = new DialogView();

        const string url =
            "https://raw.githubusercontent.com/dotnet/runtime/main/docs/coding-guidelines/coding-style.md";
        using var client = new HttpClient();
        var response = client.GetAsync(url);
        var data = response.Result.Content.ReadAsStringAsync().Result;


        if (desktop.MainWindow != null)
        {
            Dispatcher.UIThread.Invoke(() => { dialogView.ShowDialog(desktop.MainWindow); });
        }

        if (dialogView.DataContext is DialogViewModel dialogViewModel)
        {
            dialogViewModel.Content = data;
            var a = dialogViewModel.Title;
            dialogViewModel.Title = "Fuck Avalonia";
            dialogViewModel.Content = data;
        }
    }
}