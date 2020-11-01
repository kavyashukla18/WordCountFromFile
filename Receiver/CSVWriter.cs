using System.Collections.Generic;
using System.IO;

namespace Receiver
{
    public class CsvWriter
    {
        public void WriteOnCSV(string filePath, Dictionary<string, CsvDataStructure> fileContent)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var item in fileContent)
                {
                        writer.WriteLine("{0},{1}", item.Key, item.Value.WordCount);
                }
            }
        }
    }
}
