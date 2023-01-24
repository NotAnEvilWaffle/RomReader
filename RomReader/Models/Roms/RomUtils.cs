using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RomReader.Models.Roms;

public static class RomUtils
{
    public static string GetTitle(BinaryReader reader, int titleOffset )
    {
        List<byte> titleBytes = new List<byte>(); 
        reader.BaseStream.Position = titleOffset;

        while (reader.PeekChar() != -1)
        {
            byte b = reader.ReadByte();
            if (b == 0x00) break; 
            titleBytes.Add(b);
        }

        return Encoding.ASCII.GetString(titleBytes.ToArray());
    }
}