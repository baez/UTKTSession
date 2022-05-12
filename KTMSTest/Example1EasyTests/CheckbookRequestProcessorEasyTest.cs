using CheckbookPrinting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingExamples.Example1.EasyToTest;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.EasyToTest.Shared;
using UnitTestingExamples.Example1.Shared;

namespace KTMSTest.Example1EasyTests
{
    [TestClass]
    public class CheckbookRequestProcessorHardTest
    {
        [TestMethod]
        public void Process_WhenAccountExists_ShouldReturnTrue()
        {
            // Arrange
            var testAccountNumber = "123";
            var processorCheckbookPrinterAdapterMock = CheckbookProcessorTestHelper.GetProcessorCheckbookPrinterAdaperMock();
            var configurationManagerMock = new Mock<IConfigurationManager>();
            var loggerMock = new Mock<ILogger>();
            Mock<IAccountRepository> accountRepositoryMock = CheckbookProcessorTestHelper.GetAccountRepositoryMock(testAccountNumber);

            var sut = new CheckBookRequestProcessor(
                accountRepositoryMock.Object,
                configurationManagerMock.Object,
                processorCheckbookPrinterAdapterMock.Object,
                loggerMock.Object);

            //Act
            var result = sut.Process(testAccountNumber, CheckbookType.Standard, CheckbookSize.Small);

            // Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Process_WhenCheckbokPrintFails_ShouldReturnFalse()
        {
            // Arrange
            var testAccountNumber = "123";
            var expectedErrorCode = 901;
            var expectedErrorMessage = ErrorMessage.Get(expectedErrorCode);
            var processorCheckbookPrinterAdapterMock = CheckbookProcessorTestHelper.GetProcessorCheckbookPrinterAdaperMock(success: false, errorCode: expectedErrorCode);
            var configurationManagerMock = new Mock<IConfigurationManager>();
            var loggerMock = new Mock<ILogger>();
            Mock<IAccountRepository> accountRepositoryMock = CheckbookProcessorTestHelper.GetAccountRepositoryMock(testAccountNumber);

            var sut = new CheckBookRequestProcessor(
                accountRepositoryMock.Object,
                configurationManagerMock.Object,
                processorCheckbookPrinterAdapterMock.Object,
                loggerMock.Object);

            //Act
            var result = sut.Process(testAccountNumber, CheckbookType.Standard, CheckbookSize.Small);

            // Assert 
            Assert.IsFalse(result);
            loggerMock.Verify(l => l.Log(expectedErrorMessage));
        }
    }
}
