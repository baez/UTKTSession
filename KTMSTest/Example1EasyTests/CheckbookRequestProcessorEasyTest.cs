using CheckbookPrinting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingExamples.Example1.EasyToTest;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;

namespace KTMSTest.Example1EasyTests
{
    [TestClass]
    public class CheckbookRequestProcessorHardTest
    {
        [TestMethod]
        public void ProcessesPrintCheckbookRequest()
        {
            var configurationManagerMock = new Mock<IConfigurationManager>();
            var accountRepositoryMock = new Mock<IAccountRepository>();

            var checkbookRequestProcessor = new CheckBookRequestProcessor(
                configurationManagerMock.Object,
                accountRepositoryMock.Object);

            checkbookRequestProcessor.Process("123", CheckbookType.Standard, CheckbookSize.Small);

            // Assert by checking the database or the mock database
        }
    }
}
