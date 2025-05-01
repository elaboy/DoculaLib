namespace DoculaLib.Core;

public class IToken
{
    TokenType Type { get; }
    string RawValue { get; }
    
    // void Apply()
}