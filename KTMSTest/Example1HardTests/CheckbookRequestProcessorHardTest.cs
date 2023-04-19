using CheckbookPrinting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingExamples.Example1.HardToTest;
using UnitTestingExamples.Example1.Shared;

namespace KTMSTest.Example1HardTests
{
    [TestClass]
    public class CheckbookRequestProcessorHardTest
    {
        [TestMethod]
        public void ProcessesPrintCheckbookRequest()
        {
            var checkbookRequestProcessor = new CheckBookPrintProcessor();
            checkbookRequestProcessor.Process("T0017P", CheckbookType.Standard, CheckbookSize.Small);

            // Asserting the test is successful only possible by checking the database
            // or checking the printer
        }
    }
}
