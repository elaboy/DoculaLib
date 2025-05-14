namespace DoculaLib.Core.Token;

public abstract class TokenBase : IToken
{
    public abstract TokenType Type { get; }
    public string RawValue { get; protected set; }
    public void Apply(ParserContext context)
    {
        throw new NotImplementedException();
    }

    public string Value { get; protected set; }

    protected TokenBase(string rawValue)
    {
        if (string.IsNullOrWhiteSpace(rawValue))
        {
            Console.WriteLine($"{GetType().Name} has RawValue equal to null or empty.");
            throw new ArgumentNullException(nameof(rawValue));
        }

        RawValue = rawValue;
    }

    // public abstract void Apply(ParserContext context);
}