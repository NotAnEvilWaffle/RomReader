using System;
using System.Collections.Generic;
using System.IO;
using RomReader.Models.Roms;

namespace RomReader.Models;

public class RomManager
{
    
    public string Folder { get; set; }
    public IEnumerable<string> Files { get; set; }
    public List<RomFile> Roms { get; private set; }

    public RomManager(string folder)
    {
        Folder = folder;
        Files = Directory.EnumerateFiles(Folder);
        Roms = new List<RomFile>();
    }

    public List<RomFile> GetRoms() => Roms;

    public void HandleRoms()
    {
        foreach (var file in Files)
        {
            byte[] magicNumber = new byte[4];
            using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open )))
            {
                // This assumes magic number is always 4 bytes.
                // Probably not good
                reader.Read(magicNumber, 0, 4);

                if (RomInfo.magicNums.TryGetValue(magicNumber, out ConsoleRomPair? type))
                {
                    switch (type.FileType)
                    {
                        // The title offsets should be made into a lookup table
                        case _FileType.Z64:
                            Roms.Add(new N64Rom(RomUtils.GetTitle(reader, 0x20), type));
                            break;
                        case _FileType.WBFS:
                            Roms.Add(new WiiRom(RomUtils.GetTitle(reader, 0x220), type));
                            break;
                        default:
                            break;
                    }
                }


            }
        }
    }

    public void PrintRomTitles()
    {
        foreach (var rom in Roms)
        {
            Console.WriteLine(rom.Title);
        }
    }
    
}