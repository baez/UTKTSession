using CheckbookPrinting;
using KTExampleApplication.Example1.EasyToTest.Interfaces;
using Moq;
using UnitTestingExamples.Example1.EasyToTest;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared.DataModels;

namespace KTMSTest.Example1EasyTests
{
    public static class CheckbookProcessorTestHelper
    {
        public static Mock<IAccountRepository> CreateAccountRepositoryMock(string testAccountNumber)
        {
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(a => a.Get(testAccountNumber))
                .Returns(new Account()
                {
                    AccountNumber = testAccountNumber,
                    FirstName = "fn",
                    LastName = "ln",
                    Id = "",
                    LastPrintedCheckNumber = 5
                });
            return accountRepositoryMock;
        }

        public static Mock<ICheckbookProcessorPrinterAdaper> CreateProcessorCheckbookPrinterAdaperMock(bool success, int lastPrintedCheckNumber = 10)
        {
            var processorCheckbookPrinterAdapterMock = new Mock<ICheckbookProcessorPrinterAdaper>();
            processorCheckbookPrinterAdapterMock.Setup(
                p => p.Print(It.IsAny<CustomerAccount>(), It.IsAny<CheckbookType>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new CheckbookPrintResult()
                {
                    Success = success,
                    ErrorCode = success ? 0 : 101,
                    LastPrintedCheckNumber = lastPrintedCheckNumber
                });

            processorCheckbookPrinterAdapterMock.Setup(
                p => p.PrintInvoice(It.IsAny<CustomerAccount>(), It.IsAny<decimal>()))
                .Returns(new CheckbookPrintResult()
                {
                    Success = success,
                    ErrorCode = success ? 0 : 102,
                    LastPrintedCheckNumber = lastPrintedCheckNumber
                });

            return processorCheckbookPrinterAdapterMock;
        }

        public static CheckBookPrintProcessor CreateCheckBookPrintProcessor(string testAccountId, bool success)
        {
            Mock<ICheckbookProcessorPrinterAdaper> processorCheckbookPrinterAdapterMock;
            processorCheckbookPrinterAdapterMock = CheckbookProcessorTestHelper.CreateProcessorCheckbookPrinterAdaperMock(success);
            
            var configurationManagerMock = new Mock<IConfigurationManager>();
            var loggerMock = new Mock<ILogger>();
            var invoiceCalculator = new Mock<IInvoiceCalculator>();
            Mock<IAccountRepository> accountRepositoryMock = CheckbookProcessorTestHelper.CreateAccountRepositoryMock(testAccountId);

            return new CheckBookPrintProcessor(
                accountRepositoryMock.Object,
                configurationManagerMock.Object,
                processorCheckbookPrinterAdapterMock.Object,
                invoiceCalculator.Object,
                loggerMock.Object);
        }
    }
}
