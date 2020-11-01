using System;
using System.Collections.Generic;
using System.IO;

namespace Receiver
{
    public static class Utility
    {
        public static bool CreateFile(string fileName)
        {
            var curDir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(curDir, fileName);
            if (!File.Exists(fileName))
            {
                File.Create(filePath).Close();
                return false;
            }
            return true;
        } 
        public static Dictionary<string, CsvDataStructure> ReadFromFile
            (StreamReader sr, Dictionary<string,CsvDataStructure> fileContent)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var words = line.Split(',');
                try
                {
                    CsvDataManipulator.AddDataInList(words[0], words[1],fileContent);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error while reading the file");
                }
            }
            sr.Close();
            return fileContent;
        }
        public static Dictionary<string, CsvDataStructure> ReadFromConsole
            (Dictionary<string, CsvDataStructure> fileContent)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                HandleError.IfErrorLogInConsole(line);
                var words= line.Split();
                string date = StringPreProcessor.ReturnStringIfStringIsDate(words[0]); 
                foreach (var word in words)
                {
                    string stringOnly = StringPreProcessor.RemoveSymbolsAndReturnString(word);
                    bool isStringValid = StringPreProcessor.IsValidString(word);
                    if (isStringValid)
                    {
                        try
                        {
                            CsvDataManipulator.AddDataInList(stringOnly, "1",fileContent);
                        }
                        catch (ArgumentException)
                        {
                            var mapedObj = fileContent[stringOnly];
                            mapedObj.WordCount = (int.Parse(mapedObj.WordCount) + 1).ToString();
                            CsvDataManipulator.AppendDateInListIfNotInList(date, mapedObj);
                            fileContent[stringOnly] = mapedObj;
                        }
                    }
                }
            }
            return fileContent;
        }
    }
}
