using CheckbookPrinting;
using Moq;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;

namespace KTMSTest.Example1EasyTests
{
    public static class CheckbookProcessorTestHelper
    {
        public static Mock<IAccountRepository> GetAccountRepositoryMock(string testAccountNumber)
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

        public static Mock<ICheckbookProcessorPrinterAdaper> GetProcessorCheckbookPrinterAdaperMock(bool success = true, int errorCode = 0, int lastPrintedCheckNumber = 10)
        {
            var processorCheckbookPrinterAdapterMock = new Mock<ICheckbookProcessorPrinterAdaper>();
            processorCheckbookPrinterAdapterMock.Setup(p => p.Print(It.IsAny<CustomerAccount>(), It.IsAny<CheckbookType>(), It.IsAny<int>()))
                .Returns(new CheckbookPrintResult()
                {
                    Success = success,
                    ErrorCode = errorCode,
                    LastPrintedCheckNumber = lastPrintedCheckNumber.ToString()
                });

            return processorCheckbookPrinterAdapterMock;
        }
    }
}
