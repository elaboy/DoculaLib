namespace DoculaLib.Core;

public class PdfObject
{
}

public class Page
{
    public Pages Parent { get; set; }
    // public MediaBox MediaBox { get; set; } //inherited
    // public Contents Contents { get; set; } //stream or array of streams
    // public Resources Resources { get; set; } // fonts and images inherited from the parent /Pages
}

public class Pages
{
    public Array MediaBox { get; set; }
    public string[] Contents { get; set; }
    public string[] Resources { get; set; }
    
}
