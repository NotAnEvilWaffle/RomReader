using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using ReactiveUI;
using RomReader.Models;
using RomReader.Util;

namespace RomReader.ViewModels;

public class RomViewModel : ViewModelBase
{
    private readonly ObservableAsPropertyHelper<Bitmap> _coverImg;
    public ReactiveCommand<Unit, Bitmap> LoadCover { get; }
    public Bitmap Cover => _coverImg.Value;


    private RomFile _romFile;

    public RomViewModel(RomFile romFile)
    {
        RomFile = romFile;
        LoadCover = ReactiveCommand.CreateFromTask(SetCoverFromUrl);
        _coverImg = LoadCover.ToProperty(this, x => x.Cover, scheduler: RxApp.MainThreadScheduler);
        LoadCover.Execute().Subscribe();
        
        Debug.WriteLine(Cover);
    }

    public RomFile RomFile
    {
        get => _romFile;
        set => this.RaiseAndSetIfChanged(ref _romFile, value);

    }

    public async Task<Bitmap> SetCoverFromUrl()
    {
        var artUrl = await IgdbUtils.GetBoxArtByTitle(RomFile.GetTitleCaseTitle().Trim());
        
        if (artUrl == String.Empty) return null;
        
        Debug.WriteLine("The art URL is: " + artUrl);
        Bitmap cover = null;
        try
        {
            using (var httpClient = new HttpClient())
            {
                var bytes = await httpClient.GetByteArrayAsync("https:" + artUrl);
                Stream stream = new MemoryStream(bytes);
                cover = await Task.Run((() => Bitmap.DecodeToWidth(stream, 400)));
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
        return cover;
    }
}