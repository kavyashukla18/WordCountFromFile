using System.IO;
using Xunit;

namespace Receiver.Test
{
    public class TestStringPreProcessor
    {
        [Fact]
        public void TestIsValidString()
        {
            bool stringIsDate = StringPreProcessor.IsValidString("04-02-2020");
            bool isValidString = StringPreProcessor.IsValidString("review");
            Assert.False(stringIsDate);
            Assert.True(isValidString);
        }

        [Fact]
        public void TestReturnStringIfStringIsDate()
        {
            string isDate = StringPreProcessor.ReturnStringIfStringIsDate("04/05/2020");
            string isNotDate = StringPreProcessor.ReturnStringIfStringIsDate("review");
            Assert.NotNull(isDate);
            Assert.Null(isNotDate);
        }

        [Fact]
        public void TestRemoveSymbolsAndReturnString()
        {
            string stringInput = StringPreProcessor.RemoveSymbolsAndReturnString("@&56Review.");
            string stringOutput = "56review.";
            string symbolOnly = StringPreProcessor.RemoveSymbolsAndReturnString("#$$$###");
            Assert.Equal(stringOutput, stringInput);
            Assert.Equal(0, symbolOnly.Length);
        }

        [Fact]
        public void TestisValidStringForWordNotExists()
        {
            Assert.True(StringPreProcessor.IsValidString("invalid"));
        }
    }
}
