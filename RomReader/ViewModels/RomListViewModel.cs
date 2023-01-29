
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;
using RomReader.Models;

namespace RomReader.ViewModels;

public class RomListViewModel : ViewModelBase
{
    private ObservableCollection<RomFile> Roms { get; }

    public RomListViewModel(List<RomFile> roms)
    {
        Roms = new ObservableCollection<RomFile>(roms);
    }
}