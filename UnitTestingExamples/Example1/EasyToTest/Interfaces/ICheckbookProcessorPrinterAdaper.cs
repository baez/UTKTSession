using CheckbookPrinting;

namespace UnitTestingExamples.Example1.EasyToTest.Interfaces
{
    public interface ICheckbookProcessorPrinterAdaper
    {
        CheckbookPrintResult Print(CustomerAccount customer, CheckbookType checkbookType, int numberOfChecks, int lastPrintedCheck);

        CheckbookPrintResult PrintInvoice(CustomerAccount customerAccount, decimal amount);
    }
}
