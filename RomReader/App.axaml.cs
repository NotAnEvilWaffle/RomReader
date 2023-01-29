using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RomReader.Models;
using RomReader.ViewModels;

namespace RomReader;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var rm = new RomManager("E:\\Test Roms\\");
            rm.HandleRoms();

            desktop.MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(rm),
            };
        }
    }
}