namespace KTExampleApplication.Example1.EasyToTest
{
    using System;
    using CheckbookPrinting;
    using ExampleApplications.Example1.Shared.DataModels;
    using KTExampleApplication.Example1.EasyToTest.Interfaces;
    using UnitTestingExamples.Example1.Shared;

    public class InvoiceCalculator : IInvoiceCalculator
    {
        public decimal CalculateInvoice(AccountType accountType, CheckbookType checkbookType, CheckbookSize checkbookSize)
        {
            switch (accountType)
            {
                case AccountType.Personal:
                    if (checkbookType == CheckbookType.Business)
                    {
                        if (checkbookSize == CheckbookSize.Small)
                            return 20m;
                        else if (checkbookSize == CheckbookSize.Medium)
                            return 40m;
                        else if (checkbookSize == CheckbookSize.Large)
                            return 50m;
                    }
                    else if (checkbookType == CheckbookType.Elite)
                    {
                        if (checkbookSize == CheckbookSize.Small)
                            return 30m;
                        else if (checkbookSize == CheckbookSize.Medium)
                            return 50m;
                        else if (checkbookSize == CheckbookSize.Large)
                            return 60m;
                    }
                    return 0m;
                case AccountType.Business:
                    if (checkbookType == CheckbookType.Elite)
                    {
                        if (checkbookSize == CheckbookSize.Small)
                            return 10m;
                        else if (checkbookSize == CheckbookSize.Medium)
                            return 30m;
                        else if (checkbookSize == CheckbookSize.Large)
                            return 40m;
                    }
                    return 0m;
                case AccountType.BusinessElite:
                    return 0m;
                default:
                    throw new ArgumentOutOfRangeException(nameof(accountType));
            }
        }
    }
}
