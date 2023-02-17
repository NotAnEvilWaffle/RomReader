
using System.Buffers.Text;

namespace RomReader.Models.Roms;

public class N64Rom : RomFile
{
    public N64Rom(string title, ConsoleRomPair pair) : base(pair, title)
    {
        
    }
}