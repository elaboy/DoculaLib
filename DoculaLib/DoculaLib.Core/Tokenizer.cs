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
                byte newlineByte = asciiEncoder.GetBytes("\n").First();
                //while next char isn't null, need to figure out if this is enough
                while (reader.PeekChar() != -1)
                {
                    //header
                    if (reader.PeekChar() == commentByte && BytesList.Count == 0)
                    {
                        byte[] header = reader.ReadBytes(9);
                        BytesList.Add(header);
                        continue;
                    }

                    //comment
                    if (reader.PeekChar() == commentByte)
                    {
                        Stack<byte> stack = new Stack<byte>();
                        while (reader.PeekChar() != newlineByte)
                        {
                            stack.Push(reader.ReadByte());
                        }

                        byte[] comment = stack.Reverse().ToArray();
                        BytesList.Add(comment);
                    }

                    //obj
                    long pos = reader.BaseStream.Position;
                    string next20 = new string(reader.ReadChars(20));
                    reader.BaseStream.Position = pos;

                    if (next20.Contains(" obj")) // crude but effective for now
                    {
                        long originalPosition = reader.BaseStream.Position;
                        long endObjIndex;

                        bool found = FoundEndObject(reader, out endObjIndex);

                        if (found)
                        {
                            reader.BaseStream.Position = originalPosition;
                            byte[] obj = reader.ReadBytes((int)(endObjIndex - originalPosition));
                            BytesList.Add(obj);
                        }
                    }

                    if (next20.Contains("xref"))
                    {
                        long originalPosition = reader.BaseStream.Position;
                        long endXrefIndex;
                        
                        bool found = FoundXRef(reader, out endXrefIndex);

                        if (found)
                        {
                            reader.BaseStream.Position = originalPosition;
                            byte[] xref = reader.ReadBytes((int)(endXrefIndex - originalPosition));
                            BytesList.Add(xref);
                        }
                    }
                }

                int zero = 0;
            }
        }
    }

    bool FoundXRef(BinaryReader reader, out long endOfXRefIndex)
    {
        char[] buffer = new char[4];
        endOfXRefIndex = 0;

        while (reader.PeekChar() != -1)
        {
            char chr = reader.ReadChar();

            for (int i = 0; i < buffer.Length - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }
            
            buffer[buffer.Length - 1] = chr;

            if (new string(buffer) == "xref")
            {
                //search for trailer to update enOfXRefIndex
                
                endOfXRefIndex = reader.BaseStream.Position - 1;
                return true;
            }
        }
        return false;
    }

    // bool FoundTrailer(BinaryReader reader, out long endOfTrailer)
    // {
    //     
    // }

    bool FoundEndObject(BinaryReader reader, out long endobjIndex)
    {
        char[] buffer = new char[6];
        endobjIndex = 0;

        while (reader.PeekChar() != -1)
        {
            char chr = (char)reader.ReadChar();

            for (int i = 0; i < buffer.Length - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }

            buffer[buffer.Length - 1] = chr;

            if (new string(buffer) == "endobj")
            {
                endobjIndex = reader.BaseStream.Position;
                return true;
            }
        }

        return false;
    }
}