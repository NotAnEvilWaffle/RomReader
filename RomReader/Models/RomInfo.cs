using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace RomReader.Models;

public static class RomInfo
{
    public static readonly ReadOnlyDictionary<byte[], ConsoleRomPair> magicNums;
   
    // N64
    private static readonly byte[] z64 = new byte[] { 0x80, 0x37, 0x12, 0x40 };  
    
    // Wii
    private static readonly byte[] wbfs = new byte[] {0x57, 0x42, 0x46, 0x53};  
    
    static RomInfo()
    {

        IDictionary<byte[], ConsoleRomPair> dict = new Dictionary<byte[], ConsoleRomPair>(new ByteArrayComparer())
        {
            {z64, new ConsoleRomPair(_ConsoleType.N64, _FileType.Z64)},
            {wbfs, new ConsoleRomPair(_ConsoleType.Wii, _FileType.WBFS)}
        };
        magicNums = new ReadOnlyDictionary<byte[], ConsoleRomPair>(dict);
    }

}

public class ByteArrayComparer : IEqualityComparer<byte[]>
{
    //    Private backing field for the Default property below.
    private static ByteArrayComparer _default;

    /// <summary>
    ///    Default instance of <see cref = "ByteArrayComparer"/>
    /// </summary>
    public static ByteArrayComparer Default
    {
        get
        {
            if (_default == null)
            {
                _default = new ByteArrayComparer();
            }

            return _default;
        }
    }

    /// <summary>
    ///    Tests for equality between two byte arrays based on their value
    ///    sequences.
    ///	<param name = "obj1">A byte array to test for equality against obj2.</param>
    /// <param name = "obj2">A byte array to test for equality againts obj1.</param>
    /// </summary>
    public bool Equals(byte[] obj1, byte[] obj2)
    {
        //    We can make use of the StructuralEqualityComparar class to see if these
        //    two arrays are equaly based on their value sequences.
        return StructuralComparisons.StructuralEqualityComparer.Equals(obj1, obj2);
    }

    /// <summary>
    ///    Gets a hash code to identify the given object.
    /// </summary>
    /// <param name = "obj">The byte array to generate a hash code for.</param>
    public int GetHashCode(byte[] obj)
    {
        //    Just like in the Equals method, we can use the StructuralEqualityComparer
        //    class to generate a hashcode for the object.
        return StructuralComparisons.StructuralEqualityComparer.GetHashCode(obj);
    }
}