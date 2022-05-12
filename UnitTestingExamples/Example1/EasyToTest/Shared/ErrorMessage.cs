using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExamples.Example1.EasyToTest.Shared
{
    public static class ErrorMessage
    {
        public const string CheckbookPrinterFailedMessageTemplate = "CheckbookPrinter Failed ErrorCode: {0}";

        public static string Get(int errorCode)
        {
            return string.Format(ErrorMessage.CheckbookPrinterFailedMessageTemplate, errorCode);
        }
    }
}
