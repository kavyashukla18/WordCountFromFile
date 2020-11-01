using System.IO;
using Xunit;

namespace Receiver.Test
{
    [Collection("Receiver")]
    public class TestStreamReadWrite 
    {
        [Fact]
        public void TestStreamReturnObject()
        {
            StreamReadWrite sReadWrite = new StreamReadWrite();
            string fileName = "text.txt";
            // bool isFileExist = File.Exists(fileName);
            StreamReader sr = sReadWrite.StreamReturnObject(fileName);
            Assert.Null(sr);
        }
    }
}
