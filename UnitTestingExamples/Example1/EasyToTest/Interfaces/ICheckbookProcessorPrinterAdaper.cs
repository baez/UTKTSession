using CheckbookPrinting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExamples.Example1.EasyToTest.Interfaces
{
    public interface ICheckbookProcessorPrinterAdaper
    {
        CheckbookPrintResult Print(CustomerAccount customer, CheckbookType checkbookType, int numberOfChecks);
    }
}
