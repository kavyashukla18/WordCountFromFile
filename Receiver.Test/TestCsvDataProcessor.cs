using Xunit;

namespace Receiver.Test
{
    public class TestCsvDataProcessor
    {
        [Fact]
        public void TestAppendDateInListIfNotInList()
        {
            CsvDataStructure csvData = csvData = new CsvDataStructure();
            CsvDataManipulator.AppendDateInListIfNotInList("04/02/2020", csvData);
            CsvDataManipulator.AppendDateInListIfNotInList("07/02/2020", csvData);
            CsvDataManipulator.AppendDateInListIfNotInList("09/02/2020", csvData);
            Assert.NotNull(csvData.Date);
        }
    }
}
