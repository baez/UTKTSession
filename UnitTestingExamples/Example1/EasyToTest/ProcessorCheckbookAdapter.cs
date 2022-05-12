using CheckbookPrinting;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class ProcessorCheckbookAdapter : IProcessorCheckbookPrinterAdaper
    {
        public CheckbookPrintResult Print(CustomerAccount customerAccount, CheckbookType checkbookType, int numberOfChecks)
        {
            return CheckbookPrinter.Print(customerAccount, checkbookType, numberOfChecks);
        }
    }
}
