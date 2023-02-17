
using System.Globalization;
using System.Reactive.Disposables;
using ReactiveUI;

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

    public ConsoleRomPair _ConsoleRomPair;

    public string Title { get; set; }
    public _ConsoleType ConsoleType { get; set; }
    public ConsoleRomPair ConsoleRomPair { get; set; }
    
    
    
    protected RomFile(ConsoleRomPair pair, string title)
    {

        ConsoleRomPair = pair;
        ConsoleType = pair.ConsoleType;
        Title = title;
    }


    public string ConsoleTypeString
    {
        get { return this.GetConsoleTypeString(); }
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