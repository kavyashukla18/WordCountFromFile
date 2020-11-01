using System;
using System.Text;
using System.IO;

namespace Receiver
{
    public static class StringPreProcessor
    {
        private static bool IsStringIsNull(string word)
        {
            return (word == null);
        }

        public static bool IsValidString(string word)
        {
            bool isStopWord = RemoveStopWord(word);
            bool isDate = CheckStringIsDate(word);
            bool isStringNull = IsStringIsNull(word);
            if (isStopWord == isDate == isStringNull == false)
                return true;
            return false;
        }
        private static bool CheckStringIsDate(string date)
        {
            return DateTime.TryParse(date, out _);
        }
        public static string ReturnStringIfStringIsDate(string date)
        {
            if (CheckStringIsDate(date))
                return date;
            return null;
        }
        private static bool IsDigit(char letter)
        {
            return (letter >= '0' && letter <= '9');
        }
        private static bool IsAlphabetInUpperCase(char letter)
        {
            return (letter >= 'A' && letter <= 'Z');
        }

        private static bool IsAlphabetInLowerCase(char letter)
        {
            return (letter >= 'a' && letter <= 'z');
        }
        private static bool IsAlphabet(char letter)
        {
            var isAlpabetinLowerCase = IsAlphabetInLowerCase(letter);
            var isAlphabetinUpperCase = IsAlphabetInUpperCase(letter);
            return (isAlpabetinLowerCase || isAlphabetinUpperCase);
        }

        private static bool IsSymbolIsDot(char letter)
        {
            return (letter == '.');
        }
        private static bool IsSymbolIsUnderScore(char letter)
        {
            return (letter == '_');
        }
        private static bool IsSymbolIsDash(char letter)
        {
            return (letter == '-'); 
        }
        private static bool IsSymbol(char letter)
        {
            var isSymbolIsDot = IsSymbolIsDot(letter);
            var isSymbolIsDash = IsSymbolIsDash(letter);
            var isSymbolIsUnderScore = IsSymbolIsUnderScore(letter);
            return (isSymbolIsDash || isSymbolIsDot || isSymbolIsUnderScore);
        }

        private static bool IsLetterIsAppended(char letter)
        {
            bool isDigit = IsDigit(letter);
            bool isAlphabet = IsAlphabet(letter);
            bool isSymbol = IsSymbol(letter);
            return (isDigit || isAlphabet || isSymbol);
        }
        public static string RemoveSymbolsAndReturnString(string word)
        {
            StringBuilder stringOnly = new StringBuilder();
            foreach (char letter in word)
            {
                var isLetterIsAppended = IsLetterIsAppended(letter);
                if (isLetterIsAppended)
                {
                    stringOnly.Append(letter);
                }
            }
            return stringOnly.ToString().ToLower();
        }
        private static bool IsWordInStopWordFile(string word, string line)
        {
            return (line.Contains(word));
        }
        private static bool RemoveStopWord(string word)
        {
            StreamReadWrite srw = new StreamReadWrite();
			string filePath = "resources/stopwords.csv";            
            bool isFilePathExist = File.Exists(filePath);
            if (isFilePathExist)
            {
                StreamReader sr = srw.StreamReturnObject(filePath);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var words = line.Split(',');
                    bool isWordInStopWordFile = IsWordInStopWordFile(word, words[0]);
                    if (isWordInStopWordFile)
                    {
                        sr.Close();
                        return true;
                    }
                }
                sr.Close();
            }
            return false;
        }
    }
}
