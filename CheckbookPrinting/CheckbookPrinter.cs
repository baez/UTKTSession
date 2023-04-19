using System;

namespace CheckbookPrinting
{
    public static class CheckbookPrinter
    {
        public static CheckbookPrintResult Print(CustomerAccount customerAccount, CheckbookType checkbookType, int numberOfChecks, int startCheckNumber)
        {
            return new CheckbookPrintResult() { Success = true, LastPrintedCheckNumber = startCheckNumber + numberOfChecks };
        }

        public static CheckbookPrintResult PrintInvoice(CustomerAccount customerAccount, decimal amount)
        {
            return new CheckbookPrintResult() { Success = true };
        }

        public static void PrintPackageProductionStamp(DateTime printDateTime)
        {
            throw new NotImplementedException();
        }

        public static void UpdateCheckbookPageSize(decimal pageWidth, decimal pageLength)
        {
            throw new NotImplementedException();
        }

        public static void UpdateCheckSize(decimal checkWidth, decimal checkLength)
        {
            throw new NotImplementedException();
        }
    }
}
