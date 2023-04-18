using CheckbookPrinting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
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
            checkbookRequestProcessor.Process("123", CheckbookType.Standard, CheckbookSize.Small);

            // Assert by checking the database or the mock database
        }
    }
}
