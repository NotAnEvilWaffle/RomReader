using System;
using Avalonia.Controls;
using RomReader.Models;

namespace RomReader;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Console.WriteLine("TESTING WORKING!");
        // var manager = new RomManager("E:\\Test Roms\\");
        // manager.HandleRoms();
        // manager.PrintRomTitles();
    }
}