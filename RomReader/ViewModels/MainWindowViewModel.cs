using RomReader.Models;

namespace RomReader.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public RomListViewModel RomList { get; }
    
    public MainWindowViewModel(RomManager rm)
    {
        RomList = new RomListViewModel(rm.GetRoms());
    }
}