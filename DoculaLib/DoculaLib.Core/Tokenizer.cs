using System.Text;

namespace DoculaLib.Core;

public class Tokenizer
{
    public string FilePath { get; set; }
    List<byte[]> BytesList = new List<byte[]>();

    public Tokenizer(string filePath)
    {
        this.FilePath = filePath;
        var asciiEncoder =
            Encoding.GetEncoding("ASCII", EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
        
        using (var stream = File.Open(FilePath, FileMode.Open))
        {
            using (var reader = new BinaryReader(stream, Encoding.ASCII, false))
            {
                byte whitespaceByte = asciiEncoder.GetBytes(" ").First();
                byte commentByte = asciiEncoder.GetBytes("%").First();
                while (reader.PeekChar() != -1)
                {
                    //header
                    if (reader.PeekChar() == 37 && BytesList.Count == 0)
                    {
                        byte[] header = reader.ReadBytes(8);
                        BytesList.Add(header);
                    }

                    //comment
                    if (reader.PeekChar() == 37)
                    {
                        Stack<byte> stack = new Stack<byte>();
                        while (reader.PeekChar() != whitespaceByte)
                        {
                            stack.Push(reader.ReadByte());
                        }
                        byte[] comment = stack.Reverse().ToArray();
                        BytesList.Add(comment);
                    }
                }

                int zero = 0;
            }
        }
    }
}