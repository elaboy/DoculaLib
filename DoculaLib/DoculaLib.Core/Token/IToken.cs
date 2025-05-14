namespace DoculaLib.Core.Token;

public interface IToken
{
    TokenType Type { get; }
    string RawValue { get; }

    void Apply(ParserContext context);
}