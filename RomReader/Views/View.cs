using Avalonia.Controls;

namespace RomReader.Views;

public class View<T> : UserControl where T : class
{
    public new T DataContext { get; set; } = null!;
}