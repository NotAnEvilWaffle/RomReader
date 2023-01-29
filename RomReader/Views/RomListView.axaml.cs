using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RomReader.Views;

public partial class RomListView : UserControl
{
    public RomListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}