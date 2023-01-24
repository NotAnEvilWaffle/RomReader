
using System.Buffers.Text;

namespace RomReader.Models.Roms;

// z64: 80 37 12 40

public class N64Rom : RomFile
{
    public N64Rom(string title) : base(_ConsoleType.N64, title)
    {
        
    }
}