using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("sender.Test")]
namespace sender
{
    public class CsvReader
    {
        internal void WriteWordOnConsole(StreamReader reader, [Optional] string columnFilter)
        {
            reader.ReadLine();      // Remove title of columns
            
            if (columnFilter == null)
                    WriteWordOnConsoleNoColumnFilter(reader);
            else
            {
                int columnName;
                try
                {
                    columnName = int.Parse(columnFilter);
                }
                catch(FormatException)
                {
                    Writer.WriterOnConsole("2(0xA)");
                    return;
                }
                WriteWordOnConsoleWithColumnFilter(reader, columnName);
            }
            
            reader.Close();
        }

        public string[] SplitRowBasedOnSeperator(string row, char seperator)
        {
            if (row.Contains(seperator))
            {
                return row.Split(seperator);
            }
            return new[] { "" };
        }
        private void WriteWordOnConsoleNoColumnFilter(StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                var commentString = SplitRowBasedOnSeperator(row, ',');
                for (var column = 0; column < commentString.Length; column++)
                {
                    Writer.WriterOnConsole(commentString[column] + " ");
                }
                Writer.WriterOnConsole("\n");
            }
        }

        private void WriteWordOnConsoleWithColumnFilter(StreamReader reader, int columnFilter)
        {
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                var commentString = SplitRowBasedOnSeperator(row, ',');
                try
                {
                    Writer.WriterOnConsole(commentString[columnFilter] + " ");
                }
                catch (IndexOutOfRangeException)
                {
                    //Skip the row
                }
            }
        }
    }
}
