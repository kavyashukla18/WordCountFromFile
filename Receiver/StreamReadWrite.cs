using System;
using System.IO;

namespace Receiver
{
    public class StreamReadWrite
    {
        public StreamReader StreamReturnObject(string fileName)
        {
            try
            {
                var sr = new StreamReader(fileName);
                return sr;
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Unable to read or write file");
                return null;
            }
        }
    }
}
