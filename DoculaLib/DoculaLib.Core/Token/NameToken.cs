namespace DoculaLib.Core.Token;

public class NameToken : TokenBase
{
    public override TokenType Type => TokenType.Name;

    public NameToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue.Split("/").Last();
        this.RawValue = rawValue;
    }
}

public class KeywordToken : TokenBase
{
    public override TokenType Type => TokenType.Keyword;

    public KeywordToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class NumberToken : TokenBase
{
    public override TokenType Type => TokenType.Number;

    public NumberToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class StringToken : TokenBase
{
    public override TokenType Type => TokenType.String;

    public StringToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class HexStringToken : TokenBase
{
    public override TokenType Type => TokenType.HexString;

    public HexStringToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class ArrayStartToken : TokenBase
{
    public override TokenType Type => TokenType.ArrayStart;

    public ArrayStartToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class ArrayEndToken : TokenBase
{
    public override TokenType Type => TokenType.ArrayEnd;

    public ArrayEndToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class DictionaryStartToken : TokenBase
{
    public override TokenType Type => TokenType.DictionaryStart;

    public DictionaryStartToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class DictionaryEndToken : TokenBase
{
    public override TokenType Type => TokenType.DictionaryEnd;

    public DictionaryEndToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class ReferenceToken : TokenBase
{
    public override TokenType Type => TokenType.Reference;

    public ReferenceToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class OperatorToken : TokenBase
{
    public override TokenType Type => TokenType.Operator;

    public OperatorToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class CommentToken : TokenBase
{
    public override TokenType Type => TokenType.Comment;

    public CommentToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}

public class EOFToken : TokenBase
{
    public override TokenType Type => TokenType.EOF;

    public EOFToken(string rawValue) : base(rawValue)
    {
        this.Value = rawValue;
    }
}