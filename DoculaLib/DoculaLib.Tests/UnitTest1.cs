using System.Text;

namespace DoculaLibTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        string fileName = "resources/HP_testing.pdf";

        // Create a StreamReader
        using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(buffer);
            string decodedString = Encoding.UTF8.GetString(buffer);
            Console.WriteLine(decodedString);
            // Now buffer contains the raw bytes of the PDF
        }

        Assert.Pass();
    }
}