namespace DoculaLib.Core.Token;

public class NameToken : TokenBase
{
    public override TokenType Type => TokenType.Name;

    public NameToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue.Split("/").Last();
    }
}