using System;
using System.Collections.Generic;
using System.Text;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.HardToTest
{
    public class CheckBookRequestProcessor
    {
        public void Process(string accountNumber, CheckbookType checkbookType, CheckbookSize checkbookSize)
        {
            try
            {
                // Get the last printed check number for customer account
                var accountRepository = new AccountRepository();
                var customerAccount = accountRepository.Get(accountNumber);

                // Get the checkbook size (# of checks in a checkbook)
                var checkbookPackSize = ConfigurationManager.GetNumberOfChecksToPrint(checkbookSize);

                // Print the checks
                CheckbookPrinter.Print(customerAccount, checkbookType, checkbookPackSize);

                // Update user account with the last printed check number 
                var lastPrintedCheckNumber = customerAccount.LastPrintedCheckNumber + checkbookPackSize;
                accountRepository.SetLastCheckNumber(customerAccount.AccountNumber, lastPrintedCheckNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
