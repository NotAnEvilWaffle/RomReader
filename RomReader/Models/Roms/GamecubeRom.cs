namespace RomReader.Models.Roms;

public class GamecubeRom : RomFile
{
    public GamecubeRom(string title) : base(_ConsoleType.GC, title)
    {
        
    }
}