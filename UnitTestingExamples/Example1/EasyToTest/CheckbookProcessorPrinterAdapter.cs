using CheckbookPrinting;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class CheckbookProcessorPrinterAdapter : ICheckbookProcessorPrinterAdaper
    {
        public CheckbookPrintResult Print(CustomerAccount customerAccount, CheckbookType checkbookType, int numberOfChecks)
        {
            return CheckbookPrinter.Print(customerAccount, checkbookType, numberOfChecks);
        }
    }
}
