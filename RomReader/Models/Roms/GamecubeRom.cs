namespace RomReader.Models.Roms;

public class GamecubeRom : RomFile
{
    public GamecubeRom(string title, ConsoleRomPair pair) : base(pair, title)
    {
        
    }
}