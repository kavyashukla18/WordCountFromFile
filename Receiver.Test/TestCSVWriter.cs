using System.Collections.Generic;
using Xunit;
using static Receiver.Test.ReceiverTestUtility;

namespace Receiver.Test
{
    public class TestCsvWriter
    {
        [Fact]
        public void TestWriteOnCSV()
        {
            CsvWriter writer = new CsvWriter();
            string fileName = "TestWriteOnCSV.csv";
            string filePath = CreateTestFileAndReturnFilePath(fileName);
            Dictionary<string, CsvDataStructure> data = new Dictionary<string, CsvDataStructure>
            {
                {"view", ReturnClassObject("2")},
                {"delete", ReturnClassObject("9")},
                {"rename", ReturnClassObject("78")},
                {"forget", ReturnClassObject("34")}
            };
            writer.WriteOnCSV(filePath, data);
            Dictionary<string, CsvDataStructure> fileContent = ReadInDicFromCsv(filePath);
            Assert.Equal(ToAssertableString(data), ToAssertableString(fileContent));
        }
    }
}
