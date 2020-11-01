using System.Collections.Generic;
using System.Linq;

namespace Receiver
{
    public class CsvDataStructure
    {
        public string WordCount { get; set; }
        public readonly List<string> Date = new List<string>();
    }

    public static class CsvDataManipulator
    {
        public static void AppendDateInListIfNotInList(string date, CsvDataStructure csvObj)
        {
            if (csvObj.Date.Any(enter => enter == date))
            {
                return;
            }
            csvObj.Date.Add(date);
        }

        public static void AddDataInList(string word, string wordCount,
            Dictionary<string, CsvDataStructure> fileContent)
        {
            var listObj = new CsvDataStructure {WordCount = wordCount};
            fileContent.Add(word, listObj);
        }
    }
}
