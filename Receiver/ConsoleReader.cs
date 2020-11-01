using System.Collections.Generic;

namespace Receiver
{
    public class ConsoleReader
    {
        readonly StreamReadWrite _sReadWrite = new StreamReadWrite();
        public Dictionary<string, CsvDataStructure> Reader(string filePath)
        {
            var fileContent = new Dictionary<string, CsvDataStructure>();
            if (Utility.CreateFile(filePath))
            {
                var sr = _sReadWrite.StreamReturnObject(filePath);
                fileContent = Utility.ReadFromFile(sr, fileContent);
            }
            fileContent = Utility.ReadFromConsole(fileContent);
            return fileContent;
        }
    }
}
