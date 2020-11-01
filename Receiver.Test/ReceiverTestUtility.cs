using System.IO;
using System.Collections.Generic;
using System.Linq;
using static  System.Console;

namespace Receiver.Test
{
    static class ReceiverTestUtility
    {
        public static string ToAssertableString(Dictionary<string, CsvDataStructure> dictionary)
        {
            var pairStrings = dictionary.OrderBy(p => p.Key)
                                        .Select(p => p.Key + ": " + string.Join(", ", p.Value.WordCount));
            return string.Join("; ", pairStrings);
        }
        public static Dictionary<string, CsvDataStructure> ReadInDicFromCsv(string filePath)
        {
            Dictionary<string, CsvDataStructure> fileContent = new Dictionary<string, CsvDataStructure>();
            var sr = new StreamReader(filePath);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var words = line.Split(',');
                try
                {
                    CsvDataStructure obj = ReturnClassObject(words[1]);
                    fileContent.Add(words[0], obj);
                }
                catch (System.Exception)
                {
                    WriteLine("Error while reading the file");
                }
            }
            sr.Close();
            return fileContent;
        }
        public static string CreateTestFileAndReturnFilePath(string fileName)
        {
            string curDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(curDir, fileName);
            File.Create(filePath).Close();
            return filePath;
        }
        public static CsvDataStructure ReturnClassObject(string wordCount)
        {
            CsvDataStructure obj = new CsvDataStructure {WordCount = wordCount};
            return obj;
        }
        public static StringWriter ConsolerReaderToTestReciver()
        {
            var output = new StringWriter();
            SetOut(output);
            return output;
        }
    }
}
