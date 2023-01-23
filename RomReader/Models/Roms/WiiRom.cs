namespace RomReader.Models.Roms;

public class WiiRom : RomFile
{
    public WiiRom(string title) : base(_RomType.Wii, title)
    {
        
    }
}