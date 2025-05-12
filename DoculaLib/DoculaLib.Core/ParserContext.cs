namespace DoculaLib.Core;

public class ParserContext
{
    public int CurrentObjectNumber {get; set;}
    public int CurrentObjectGeneration { get; set; }
    
    public Stack<object> ValueStack { get; } = new();

    public bool InsideDictionary { get; set; } = false;
    public bool InsideArray { get; set; } = false;

    public Dictionary<string, object> CurrentDictionary { get; } = new();
    
    public string? PendingKey { get; set; }

    public List<string> ContentStreamCommands { get; set; } = new();

    public void Log(string message)
    {
        Console.WriteLine($"[ParserContext] {message}");
    }

    public void Reset()
    {
        CurrentDictionary.Clear();
        ValueStack.Clear();
        PendingKey = null;
        InsideDictionary = false;
        InsideArray = false;
        ContentStreamCommands.Clear();
    }
}