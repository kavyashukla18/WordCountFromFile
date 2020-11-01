using System;
using Xunit;
using static sender.Test.Utility;

namespace sender.Test
{
    [Collection("Sender")]
    public class TestCsvRead : IDisposable
    {
        readonly CsvReader _csvread;
        public TestCsvRead()
        {
            _csvread = new CsvReader();
        }

        private string CheckDataOnConsoleOnCallingWriteWordOnConsole(string col)
        {
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using var sr = CreateStreamReaderDummyCsv(filename);
            var output = ConsolerReaderForTest();
            _csvread.WriteWordOnConsole(sr, col);
            var outputResult = output.ToString();
            output.Close();
            return outputResult;
        }
        [Fact]
        public void TestWriteWordOnConsoleWithNoColFilter()
        {
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using var sr = CreateStreamReaderDummyCsv(filename);
            var output = ConsolerReaderForTest();
            _csvread.WriteWordOnConsole(sr);
            var expected_result = "4/28/2020  10:14:00 AM Comment1 \n4/27/2020  9:14:00 AM Comment2 \n";
            Assert.Equal(expected_result, output.ToString());
            output.Close();
        }
        [Fact]
        public void TestWriteWordOnConsoleWithColFilter()
        {
            var actualResult = CheckDataOnConsoleOnCallingWriteWordOnConsole("0");
            var expected_result = "4/28/2020  10:14:00 AM 4/27/2020  9:14:00 AM ";
            Assert.Equal(expected_result, actualResult);
        }
        [Fact]
        public void TestWriteWordOnConsoleForNoColData()
        {
            var actualResult = CheckDataOnConsoleOnCallingWriteWordOnConsole("2");
            const string expectedResult = "";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void TestTestWriteWordOnConsoleForNoColDataWithNoSeperator()
        {
            string[] expectedResult = { "" };
            var actualResult = _csvread.SplitRowBasedOnSeperator("\n", ',');
            Assert.Equal(expectedResult, actualResult);
        }
        public void Dispose()
        {
            RemoveCsvFile("testcsvreader.csv");
        }
    }
}
