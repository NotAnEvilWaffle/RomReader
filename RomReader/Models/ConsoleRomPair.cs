namespace RomReader.Models;

public enum _FileType
{
    // Nintendo 64
    Z64,
    N64,
    V64,
    // Nintendo Wii
    WBFS
    
}


public class ConsoleRomPair
{
    public _ConsoleType ConsoleType { get; set; }
    public _FileType FileType { get; set; }

    public ConsoleRomPair(_ConsoleType consoleType, _FileType fileType)
    {
        ConsoleType = consoleType;
        FileType = fileType;
    }
}