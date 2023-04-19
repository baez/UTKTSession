using CheckbookPrinting;
using KTExampleApplication.Example1.EasyToTest.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var testAccountId = "123";
            var sut = CheckbookProcessorTestHelper.CreateCheckBookPrintProcessor(testAccountId, true);

            //Act
            var result = sut.Process(testAccountId, CheckbookType.Standard, CheckbookSize.Small);

            // Assert 
            Assert.IsTrue(result.Success);
            Assert.AreEqual(PrintProcessorErrorCode.None, result.ErrorCode);
        }

        [TestMethod]
        public void Process_WhenCheckbokPrintFails_ShouldReturnFalse()
        {
            // Arrange
            var testAccountId = "123";
            var sut = CheckbookProcessorTestHelper.CreateCheckBookPrintProcessor(testAccountId, false);

            //Act
            var result = sut.Process(testAccountId, CheckbookType.Standard, CheckbookSize.Small);

            // Assert 
            Assert.IsFalse(result.Success);
            Assert.AreEqual(PrintProcessorErrorCode.PrinterError, result.ErrorCode);
        }
    }
}
