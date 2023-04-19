using CheckbookPrinting;
using KTExampleApplication.Example1.EasyToTest.Interfaces;
using KTExampleApplication.Example1.EasyToTest.Shared;
using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.EasyToTest.Shared;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class CheckBookPrintProcessor
    {
        private readonly IAccountRepository accountRepository;
        private readonly IConfigurationManager configurationManager;
        private readonly ICheckbookProcessorPrinterAdaper processorCheckbookPrinterAdapter;
        private readonly IInvoiceCalculator invoiceCalculator;
        private readonly ILogger logger;

        public CheckBookPrintProcessor(
            IAccountRepository accountRepository,
            IConfigurationManager configurationManager,
            ICheckbookProcessorPrinterAdaper processorCheckbookPrinterAdapter,
            IInvoiceCalculator invoiceCalculator,
            ILogger logger)
        {
            this.configurationManager = configurationManager ?? throw new ArgumentNullException(nameof(configurationManager));
            this.accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            this.processorCheckbookPrinterAdapter = processorCheckbookPrinterAdapter ?? throw new ArgumentNullException(nameof(processorCheckbookPrinterAdapter));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.invoiceCalculator = invoiceCalculator ?? throw new ArgumentNullException(nameof(invoiceCalculator));
        }

        public CheckbookPrintProcessorResult Process(string accountNumber, CheckbookType checkbookType, CheckbookSize checkbookSize)
        {
            try
            {
                // Get the last printed check number for customer account
                var account = this.accountRepository.Get(accountNumber);

                // Get the checkbook size (# of checks in a checkbook)
                var checkbookPackSize = this.configurationManager.GetNumberOfChecksToPrint(checkbookSize);

                // Map to PrintLibrary CustomerAccount
                var customerAccount = AccountMapper.Map(account);

                // Print the checks
                var printResult = this.processorCheckbookPrinterAdapter.Print(customerAccount, checkbookType, checkbookPackSize, account.LastPrintedCheckNumber);
                if (printResult.Success)
                {
                    // Update user account with the last printed check number 
                    var lastPrintedCheckNumber = customerAccount.LastPrintedCheckNumber + checkbookPackSize;
                    this.accountRepository.SetLastCheckNumber(customerAccount.AccountNumber, printResult.LastPrintedCheckNumber);
                }
                else
                {
                    var errorMessage = ErrorMessage.Get(printResult.ErrorCode);
                    this.logger.Log(errorMessage);
                    return new CheckbookPrintProcessorResult { Success = false, ErrorCode = PrintProcessorErrorCode.PrinterError };
                }

                // Print customer invoice
                var invoiceAmount = this.invoiceCalculator.CalculateInvoice(account.AccountType, checkbookType, checkbookSize);
                this.processorCheckbookPrinterAdapter.PrintInvoice(customerAccount, invoiceAmount);
            }
            catch (Exception e)
            {
                this.logger.Log(e.Message);
                return new CheckbookPrintProcessorResult { Success = false, ErrorCode = PrintProcessorErrorCode.ProcessError };
            }

            return new CheckbookPrintProcessorResult { Success = true };
        }
    }
}
