namespace DoculaLib.Core.Token;

public enum TokenType
{
    Keyword,        // obj, endobj, stream, endstream, xref
    Name,           // /Type, /Page, etc.
    Number,         // 0, 1.5, -100
    String,         // (Hello World)
    HexString,      // <48656C6C6F>
    ArrayStart,     // [
    ArrayEnd,       // ]
    DictionaryStart,// <<
    DictionaryEnd,  // >>
    Reference,      // 3 0 R
    Operator,       // BT, ET, Tj, Td (in content stream)
    Comment,        // % anything
    EOF             // End of file
}