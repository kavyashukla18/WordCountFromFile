using System;
using System.Collections.Generic;

namespace Receiver
{
    public static class HandleError
    {
        static readonly Dictionary<string, string> MapErrorCodeWithDiscription = new Dictionary<string, string>
        {
            {"2(0xA)", "Error: Invalid column argument"},
            {"2(0xF)", "invalid file name" }
        };

        public static void IfErrorLogInConsole(string errorData)
        {
            foreach (var code in MapErrorCodeWithDiscription)
            {
                if (errorData.Contains(code.Key))
                {
                    LogErrorInConsole(code.Key);
                }
            }
        }
        private static void LogErrorInConsole(string errorCode)
        {
            Console.WriteLine(MapErrorCodeWithDiscription[errorCode]);
        }
    }
}
