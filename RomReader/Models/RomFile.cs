
namespace RomReader.Models;

public enum _RomType
{
    // Nintendo 64
    N64,
    Wii,
    GC,
}


public abstract class RomFile
{
    public RomFile(_RomType romType, string title)
    {
        RomType = romType;
        Title = title;
    }
    
    public _RomType RomType { get; set; }
    public string Title { get; set; }
    
    
}