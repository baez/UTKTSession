using CheckbookPrinting;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class CheckbookProcessorPrinterAdapter : ICheckbookProcessorPrinterAdaper
    {
        public CheckbookPrintResult Print(CustomerAccount customerAccount, CheckbookType checkbookType, int numberOfChecks, int lastPrintedCheck)
        {
            return CheckbookPrinter.Print(customerAccount, checkbookType, numberOfChecks, lastPrintedCheck);
        }

        public CheckbookPrintResult PrintInvoice(CustomerAccount customerAccount, decimal amount)
        {
            return CheckbookPrinter.PrintInvoice(customerAccount, amount);
        }
    }
}
