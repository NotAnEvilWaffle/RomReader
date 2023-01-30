
using System.Globalization;

namespace RomReader.Models;

public enum _ConsoleType
{
    // Nintendo 64
    N64,
    Wii,
    GC
}

public abstract class RomFile
{
    
    public _ConsoleType ConsoleType { get; set; }
    public string Title { get; set; }
    
    protected RomFile(_ConsoleType consoleType, string title)
    {
        ConsoleType = consoleType;
        Title = title;
    }

    public string GetConsoleTypeString()
    {
        return ConsoleType.ToString();
    }

    public string GetTitleCaseTitle()
    {
        TextInfo ti = new CultureInfo("en-US", false).TextInfo;
        return ti.ToTitleCase(ti.ToLower(Title));
    }
    
    
    
    
}