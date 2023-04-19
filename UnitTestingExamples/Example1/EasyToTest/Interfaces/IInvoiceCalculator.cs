namespace KTExampleApplication.Example1.EasyToTest.Interfaces
{
    using CheckbookPrinting;
    using ExampleApplications.Example1.Shared.DataModels;
    using UnitTestingExamples.Example1.Shared;

    public interface IInvoiceCalculator
    {
        decimal CalculateInvoice(AccountType accountType, CheckbookType checkbookType, CheckbookSize checkbookSize);
    }
}
