using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Receiver.Test
{
    public class TestUtility
    {
        [Fact]
        public void TestCreateFile()
        {
            string fileName = "TestCreateFile.csv";
            if (File.Exists(fileName))
            {
                bool isFileCreated = Utility.CreateFile(fileName);
                Assert.True(isFileCreated);
            }
            else
            {
                bool isFileCreated = Utility.CreateFile(fileName);
                Assert.False(isFileCreated);
            }
        }

        [Fact]
        public void TestReadFromFile()
        {
            string fileName = "TestReadFromFile.csv";
            StreamReader sr = new StreamReader(fileName);
            Dictionary<string, CsvDataStructure> fileContent = new Dictionary<string, CsvDataStructure>();
            Dictionary<string, CsvDataStructure> output = Utility.ReadFromFile(sr, fileContent);
            Assert.NotEmpty(output);
        }
    }
}
