namespace KTMSTest.Example1EasyTests
{
    using CheckbookPrinting;
    using ExampleApplications.Example1.Shared.DataModels;
    using KTExampleApplication.Example1.EasyToTest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UnitTestingExamples.Example1.Shared;

    [TestClass]
    public class InvoiceCalculatorTest
    {
        [TestMethod]
        public void CalculateInvoice_WhenAccountTypeIsBusinessEliteForEliteCheckbook_ShouldReturnZero()
        {
            // Arrange
            var sut = new InvoiceCalculator();

            //Act
            var result = sut.CalculateInvoice(AccountType.BusinessElite, CheckbookType.Elite, CheckbookSize.Small);

            // Assert 
            Assert.AreEqual(0m, result);
        }

        [TestMethod]
        public void CalculateInvoice_WhenAccountTypeIsBusinessEliteForBusinessCheckbook_ShouldReturnZero()
        {
            // Arrange
            var sut = new InvoiceCalculator();

            //Act
            var result = sut.CalculateInvoice(AccountType.BusinessElite, CheckbookType.Business, CheckbookSize.Small);

            // Assert 
            Assert.AreEqual(0m, result);
        }

        [TestMethod]
        public void CalculateInvoice_WhenAccountTypeIsBusinessEliteForStandardCheckbook_ShouldReturnZero()
        {
            // Arrange
            var sut = new InvoiceCalculator();

            //Act
            var result = sut.CalculateInvoice(AccountType.BusinessElite, CheckbookType.Standard, CheckbookSize.Small);

            // Assert 
            Assert.AreEqual(0m, result);
        }
    }
}
