﻿using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RomReader.ViewModels;

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