namespace RomReader.Models.Roms;

public class GcRom : RomFile
{
    public GcRom(string title) : base(_RomType.GC, title)
    {
        
    }
}