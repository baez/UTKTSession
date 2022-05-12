using CheckbookPrinting;
using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.EasyToTest.Shared;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class CheckBookRequestProcessor
    {
        private readonly IAccountRepository accountRepository;
        private readonly IConfigurationManager configurationManager;
        private readonly IProcessorCheckbookPrinterAdaper processorCheckbookPrinterAdapter;
        private readonly ILogger logger;

        public CheckBookRequestProcessor(
            IAccountRepository accountRepository,
            IConfigurationManager configurationManager,
            IProcessorCheckbookPrinterAdaper processorCheckbookPrinterAdapter,
            ILogger logger)

        {
            this.configurationManager = configurationManager;
            this.accountRepository = accountRepository;
            this.processorCheckbookPrinterAdapter = processorCheckbookPrinterAdapter;
            this.logger = logger;
        }

        public bool Process(string accountNumber, CheckbookType checkbookType, CheckbookSize checkbookSize)
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
                var printResult = this.processorCheckbookPrinterAdapter.Print(customerAccount, checkbookType, checkbookPackSize);
                if (printResult.Success)
                {
                    // Update user account with the last printed check number 
                    var lastPrintedCheckNumber = customerAccount.LastPrintedCheckNumber + checkbookPackSize;
                    accountRepository.SetLastCheckNumber(customerAccount.AccountNumber, Convert.ToInt32(printResult.LastPrintedCheckNumber));
                }
                else
                {
                    var errorMessage = ErrorMessage.Get(printResult.ErrorCode);
                    this.logger.Log(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception e)
            {
                this.logger.Log(e.Message);
                return false;
            }

            return true;
        }
    }
}
