namespace RomReader.Models.Roms;

public class WiiRom : RomFile
{
    public WiiRom(string title) : base(_ConsoleType.Wii, title)
    {
        
    }
}