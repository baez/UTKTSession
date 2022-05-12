using System;

namespace CheckbookPrinting
{
    public static class CheckbookPrinter
    {
        public static CheckbookPrintResult Print(CustomerAccount customer, CheckbookType checkbookType, int numberOfChecks)
        {
            throw new NotImplementedException();
        }

        public static void PrintPackageProductionStamp(DateTime printDateTime)
        {
            throw new NotImplementedException();
        }

        public static CheckbookPrintResult Print(object customerAccount, CheckbookType checkbookType, object checkbookPackSize)
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
