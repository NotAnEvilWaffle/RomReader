using System;
using System.Collections.Generic;
using System.IO;

namespace RomReader.Models;

public class RomReader
{
    
    public string Folder { get; set; }
    public IEnumerable<string> Files { get; set; }

    public RomReader(string folder)
    {
        Folder = folder;
        Files = Directory.EnumerateFiles(Folder);
    }

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
            }
        }
    }
    
}