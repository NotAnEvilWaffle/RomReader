
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;
using RomReader.Models;
using RomReader.Models.Roms;
using RomReader.Util;

namespace RomReader.ViewModels;

public class RomListViewModel : ViewModelBase
{
    private ObservableCollection<RomViewModel> Roms { get; }
    private IgdbUtils igdb;
    private RomViewModel _selectedRomFile;

    public RomListViewModel(List<RomFile> roms)
    {
        igdb = new IgdbUtils();
        List<RomViewModel> temp = roms.Select(rvm => new RomViewModel(rvm)).ToList();
        Roms = new ObservableCollection<RomViewModel>(temp);
    }

    public RomViewModel SelectedRomFile
    {
        get => _selectedRomFile;
        set => this.RaiseAndSetIfChanged(ref _selectedRomFile, value);
    }

    public async void LoadCovers(CancellationToken cancellationToken)
    {
        foreach (var romViewModel in Roms)
        {
            await romViewModel.SetCoverFromUrl();
        }
    }

    public async Task<Unit> LoadCovers()
    {
        
        foreach (var romViewModel in Roms)
        {
            await romViewModel.SetCoverFromUrl();
        }
            
        return Unit.Default;
    }
}