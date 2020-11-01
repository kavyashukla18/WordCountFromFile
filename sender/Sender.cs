using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("sender.Test")]
namespace sender
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            StreamReader streamReader;
            try
            {
                var csvPath = args[0];
                streamReader = new StreamReader(csvPath);
            }
            catch (Exception)
            {
                Writer.WriterOnConsole("2(0xF)");
                return;
            }
            CsvReader reader = new CsvReader();
            if (args.Length <= 1)
            {
                reader.WriteWordOnConsole(streamReader);
            }
            else
            {
                reader.WriteWordOnConsole(streamReader, args[1]);
            }
            streamReader.Close();
        }
    }
}
