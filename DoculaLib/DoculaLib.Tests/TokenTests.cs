using DoculaLib.Core;
using DoculaLib.Core.Token;

namespace DoculaLibTests;

[TestFixture]
public class TokenTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void TestNameToken()
    {
        NameToken nameToken = new NameToken(rawValue: "/Type");

        Assert.That(nameToken.Type, Is.EqualTo(TokenType.Name));
        Assert.That(nameToken.RawValue, Is.EqualTo("/Type"));
        Assert.That(nameToken.Value, Is.EqualTo("Type"));
    }

    [Test]
    public void TestNameTokenNullArg()
    {
        Assert.Throws(typeof(ArgumentNullException), () =>
        {
            NameToken nameToken = new NameToken(rawValue: null);
        });
    }

    [Test]
    public void TestNameTokenWhitespaceArg()
    {
        Assert.Throws(typeof(ArgumentNullException), () =>
        {
            NameToken nameToken = new NameToken(rawValue: " ");
        });
    }
}