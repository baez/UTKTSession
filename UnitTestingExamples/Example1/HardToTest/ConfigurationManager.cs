using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExamples.Example1.HardToTest
{
    public static class ConfigurationManager
    {
        public static int NumberOfChecksPerRow { get; set; }
        public static int NumberOfRowsPerPage { get; set; }
        public static decimal checkLength { get; set; }
        public static decimal checkWidth { get; set; }
    }
}
