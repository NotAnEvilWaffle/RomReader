namespace RomReader.Models.Roms;

public class WiiRom : RomFile
{
    public WiiRom(string title, ConsoleRomPair pair) : base(pair, title)
    {
        
    }
}