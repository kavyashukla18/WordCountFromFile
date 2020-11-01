using System;
using System.Collections.Generic;
using System.IO;

namespace sender
{
    class Constants
    {
        private static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public static string csv_path = Path.Combine(projectDirectory, "resources", "review-report.csv");
    }
}
