using CheckbookPrinting;
using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class CheckBookRequestProcessor
    {
        private readonly IConfigurationManager configurationManager;
        private readonly IAccountRepository accountRepository;

        public CheckBookRequestProcessor(
            IConfigurationManager configurationManager,
            IAccountRepository accountRepository)

        {
            this.configurationManager = configurationManager;
            this.accountRepository = accountRepository;
        }

        public void Process(string accountNumber, CheckbookType checkbookType, CheckbookSize checkbookSize)
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
                var printResult = CheckbookPrinter.Print(customerAccount, checkbookType, checkbookPackSize);
                if (printResult.Success)
                {
                    // Update user account with the last printed check number 
                    var lastPrintedCheckNumber = customerAccount.LastPrintedCheckNumber + checkbookPackSize;
                    accountRepository.SetLastCheckNumber(customerAccount.AccountNumber, Convert.ToInt32(printResult.LastPrintedCheckNumber));
                }
                else
                {
                    var msg = string.Format("CheckbookPrinter Error: {0}", printResult.ErrorCode);
                    Console.WriteLine(msg);
                    throw new Exception(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
