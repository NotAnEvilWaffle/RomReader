
using System.Buffers.Text;

namespace RomReader.Models.Roms;



public class N64Rom : RomFile
{
    public N64Rom(string title) : base(_RomType.N64, title)
    {
        
    }
}