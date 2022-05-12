using System;
using System.Collections.Generic;
using System.Text;

namespace CheckbookPrinting
{
    public class CheckbookPrintResult
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string LastPrintedCheckNumber { get; set; }
    }
}
