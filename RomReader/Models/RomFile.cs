
namespace RomReader.Models;

public enum _ConsoleType
{
    // Nintendo 64
    N64,
    Wii,
    GC
}

public abstract class RomFile
{
    protected RomFile(_ConsoleType consoleType, string title)
    {
        ConsoleType = consoleType;
        Title = title;
    }
    
    public _ConsoleType ConsoleType { get; set; }
    public string Title { get; set; }
    
    
}