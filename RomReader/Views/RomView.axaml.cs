using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RomReader.Views;

public partial class RomView : UserControl
{
    public RomView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}